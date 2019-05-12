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
    [Route("api/Pick")]
    public class PickApiController : Controller
    {

        private IConfiguration _configuration;

        public PickApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Pick> Get()
        {
            DateTime time = DateTime.Now;
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Pick>("Select P2.Id, g.Id as 'GameId', ht.Name as 'HomeTeam', vt.Name as 'VisitingTeam', g.HomeTeamId, g.VisitingTeamId, pt.Name as 'TeamPick', g.GameDate, g.HomeScore, g.VisitingScore " +
                	"FROM Games g " +
                	"INNER JOIN Teams ht ON g.HomeTeamId = ht.Id " +
                	"INNER JOIN Teams vt ON g.VisitingTeamId = vt.Id " +
                	"Inner JOIN Picks P2 ON g.Id = P2.Game " +
                	"INNER JOIN Teams pt ON P2.Pick = pt.Id");

                for (int i = 0; i < data.Count(); ++i)
                {
                    Pick pick = data.ElementAt(i);
                    if (pick.GameDate > time)
                    {
                        pick.IsFuture = 1;
                    }
                    else
                    {
                        pick.IsFuture = 0;
                    }
                }


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
        public void Post([FromBody]TeamPick value)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<TeamPick>(@"INSERT INTO Picks(Pick, Game) VALUES(@Pick, @Game);
                    Select * from Picks where Id=@id", value).FirstOrDefault();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TeamPick value)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<TeamPick>(@"UPDATE Picks SET Pick=@Pick WHERE Id=@Id;
                    Select * from Picks where Id=@id", value).FirstOrDefault();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
