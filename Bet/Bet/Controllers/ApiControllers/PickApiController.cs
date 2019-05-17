using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using Bet.Models;
using Microsoft.AspNetCore.Http;

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
            int user = System.Convert.ToInt32(HttpContext.Session.GetString("User"));
            DateTime time = DateTime.Now;
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Pick>("Select P2.Id, g.Id as 'GameId', ht.Name as 'HomeTeam', vt.Name as 'VisitingTeam', g.HomeTeamId, g.VisitingTeamId, pt.Name as 'TeamPick', g.GameDate, g.HomeScore, g.VisitingScore " +
                    "FROM Games g " +
                    "INNER JOIN Teams ht ON g.HomeTeamId = ht.Id " +
                    "INNER JOIN Teams vt ON g.VisitingTeamId = vt.Id " +
                    "Inner JOIN Picks P2 ON g.Id = P2.Game " +
                    "INNER JOIN Teams pt ON P2.Pick = pt.Id " +
                    "WHERE P2.User = @user", new { user });

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
        [HttpGet("{id}/{name}")]
        public int Get(int id, string name)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                if (name == "All Teams")
                {
                    var result = db.Query<int>(@"SELECT Count(Picks.Id) "
                                    + "FROM Picks " 
                                    + "INNER JOIN Teams T ON Picks.Pick = T.Id "
                                    + "WHERE User = @id", new { id }).FirstOrDefault();
                    return result;
                }
                else
                {
                    var result = db.Query<int>(@"SELECT Count(Picks.Id) "
                                    + "FROM Picks "
                                    + "INNER JOIN Teams T ON Picks.Pick = T.Id "
                                    + "WHERE User = @id AND T.Name = @name", new { id, name }).FirstOrDefault();
                    return result;
                }
            }
        }

        // POST api/values
        //[HttpPost("allpicks")]


        // POST api/values
        [HttpPost]
        public void Post([FromBody]TeamPick value)
        {
            value.User = System.Convert.ToInt32(HttpContext.Session.GetString("User"));
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<TeamPick>(@"INSERT INTO Picks(Pick, Game, User) VALUES(@Pick, @Game, @User);
                    Select * from Picks where Id=@id", value).FirstOrDefault();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TeamPick value)
        {
            value.User = System.Convert.ToInt32(HttpContext.Session.GetString("User"));
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
