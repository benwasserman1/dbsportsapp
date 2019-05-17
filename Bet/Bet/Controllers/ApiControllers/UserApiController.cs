using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using Bet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bet.Controllers.ApiControllers
{

   
    [Route("api/User")]
    public class UserApiController : Controller
    {

        private IConfiguration _configuration;

        public UserApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            { 
                var result = db.Query<User>(@"SELECT Name, Email "
                                    + "FROM Users "
                                    + "WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                HttpContext.Session.Remove("User");
                var data = db.Query<User>(@"DELETE FROM Users WHERE Id = @id", new { id }).FirstOrDefault();

            }

        }
    }
}
