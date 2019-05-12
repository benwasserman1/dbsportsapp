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
    [Route("api/Game")]
    public class GameApiController : Controller
    {

        private IConfiguration _configuration;

        public GameApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5/name
        [HttpGet("{timeId}/{name}")]
        public IEnumerable<Game> Get(int timeId, string name)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                string currTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                string time = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss");


                if (timeId == 1)
                {
                    if (name != "Choose one")
                    {
                        // get date for tomorrow
                        time = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss");
                        var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                                "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                                "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                                " where GameDate BETWEEN @currTime AND @time " +
                                                "AND HomeTeamId = (select Id from Teams WHERE Teams.Name = @name)", new { time, currTime, name });
                        return data;
                    }
                    else
                    {
                        // get date for tomorrow
                        time = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss");
                        var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                                "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                                "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                                " where GameDate BETWEEN @currTime AND @time", new { time, currTime });
                        return data;
                    }

                }
                else if (timeId == 2)
                {
                    if (name != "Choose one")
                    {
                        // get date from one week from today
                        time = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd hh:mm:ss");
                        var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                                "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                                "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                                " where GameDate BETWEEN @currTime AND @time " +
                                                "AND HomeTeamId = (select Id from Teams WHERE Teams.Name = @name)", new { time, currTime, name });
                        return data;
                    }
                    else
                    {
                        // get date from one week from today
                        time = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd hh:mm:ss");
                        var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                                "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                                "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                                " where GameDate BETWEEN @currTime AND @time", new { time, currTime });
                        return data;
                    }

                }
                else
                {
                    if (name != "Choose one")
                    {
                        // get date from one month from today
                        time = DateTime.Now.AddMonths(-7).ToString("yyyy-MM-dd hh:mm:ss");
                        var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                                "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                                "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                                " where GameDate BETWEEN @time AND @currTime " +
                                                "AND HomeTeamId = (select Id from Teams WHERE Teams.Name = @name)", new { time, currTime, name });
                        return data;
                    }
                    else
                    {
                        // get date from one month from today
                        time = DateTime.Now.AddMonths(-7).ToString("yyyy-MM-dd hh:mm:ss");
                        var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                                "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                                "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                                " where GameDate BETWEEN @time AND @currTime", new { time, currTime });
                        return data;
                    }
                   
                }

            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            using (var db = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                db.ExecuteAsync("INSERT INTO Picks() Values()");
            }
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
