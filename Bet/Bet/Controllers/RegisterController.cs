using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bet.Controllers
{
    public class RegisterController : Controller
    {

        private IConfiguration _config;

        public RegisterController(IConfiguration config)
        {
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string uname, string psw, string email)
        {
            // pass username, password, and email to database
            using (var db = new MySqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using (MySqlCommand cmd = new MySqlCommand("InsertUsers", db))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    byte[] bytes = Encoding.ASCII.GetBytes("sdllkjd");
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: psw,
                        salt: bytes,
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 10000,
                        numBytesRequested: 256 / 8));
                    cmd.Parameters.AddWithValue("@Name", uname);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@psw", hashed);

                    cmd.ExecuteNonQuery();
                 
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
