using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using Bet.Models;
using System.Data;

using System.Web;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bet.Controllers
{
    public class FormController : Controller
    {

        private IConfiguration _config;

        public FormController(IConfiguration config)
        {
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string uname, string psw)
        {
            // return Content($"Hello {uname} with the password; {psw}");
            using (var db = new MySqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using (MySqlCommand cmd = new MySqlCommand("AuthLogUsers", db))
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
                    cmd.Parameters.AddWithValue("@pass", hashed);
                    cmd.Parameters.AddWithValue("@username", uname);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        int userId = (int)rd.GetValue(0);
                        var username = rd.GetValue(1);
                        var email = rd.GetValue(2);

                        if (uname == username.ToString())
                        {
                            HttpContext.Session.SetString("User", userId.ToString());
                            return RedirectToAction("Games", "Home");

                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
