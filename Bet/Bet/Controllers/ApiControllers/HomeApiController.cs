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
    [Route("api/Home")]
    public class HomeApiController : Controller
    {

        private IConfiguration _configuration;

        public HomeApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<User>("Select * from Users");
                return data;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        }
    }
}
