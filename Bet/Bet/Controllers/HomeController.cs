using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bet.Models;
using unirest_net.http;

using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Web;
using System.Text;
using ServiceStack.Text;
using Newtonsoft.Json;

namespace Bet.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config;

        /*

        Task<HttpResponse<MyClass>> response = Unirest.get("https://api-nba-v1.p.rapidapi.com/seasons/")
.header("X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com")
.header("X-RapidAPI-Key", "3T9gDQGL7YmshimsdqmdiWmcKGZ0p1cdCy2jsnotuUqegFIrbi")
.asJson();

*/
        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            using (var db = new MySqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                //var data = db.Query("Select * from Users");
                return View();
            }
        }

        public IActionResult Export(string table)
        {
            using (var db = new MySqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                // var data = db.Query("Select * from " + table);

                var data = db.Query<Pick>("Select P2.Id, g.Id as 'GameId', ht.Name as 'HomeTeam', vt.Name as 'VisitingTeam', g.HomeTeamId, g.VisitingTeamId, pt.Name as 'TeamPick', g.GameDate, g.HomeScore, g.VisitingScore " +
                    "FROM Games g " +
                    "INNER JOIN Teams ht ON g.HomeTeamId = ht.Id " +
                    "INNER JOIN Teams vt ON g.VisitingTeamId = vt.Id " +
                    "Inner JOIN Picks P2 ON g.Id = P2.Game " +
                    "INNER JOIN Teams pt ON P2.Pick = pt.Id");

                DateTime time = DateTime.Now;
                string stringTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

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

                // serialize to csv
                var output = CsvSerializer.SerializeToCsv(data);
                byte[] byte_array = Encoding.ASCII.GetBytes(output);

                // return file to download
                var result = new FileContentResult(byte_array, "application/octet-stream");
                result.FileDownloadName = "table: " + time + ".csv";
                return result;
            }
                
        }

        /*
        public IActionResult GetData()
        {

            HttpResponse<Player> response = Unirest.get("https://api-nba-v1.p.rapidapi.com/games/teamId/29")
               .header("X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com")
               .header("X-RapidAPI-Key", "3T9gDQGL7YmshimsdqmdiWmcKGZ0p1cdCy2jsnotuUqegFIrbi")
               .asJson<Player>();



            HttpResponse<string> sample_response = Unirest.get("https://api-nba-v1.p.rapidapi.com/seasons/")
                .header("X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com")
                .header("X-RapidAPI-Key", "3T9gDQGL7YmshimsdqmdiWmcKGZ0p1cdCy2jsnotuUqegFIrbi")
                .asJson<string>();

            var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(sample_response.Body);
                      

            Console.Write(obj);

            return View();
        }
        */

        public IActionResult About()
        {
            ViewData["Message"] = "Rules for your NBA betting";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Reach out for help with your NBA betting";

            return View();
        }

        public IActionResult Games()
        {
            ViewData["Message"] = "See games and make picks";

            using (var db = new MySqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                string time = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss");
                var data = db.Query<Game>("Select Games.Id, GameDate, HomeScore, VisitingScore, t.Name as 'HomeTeam', f.Name as 'VisitingTeam', HomeTeamId, VisitingTeamId " +
                                            "from Games inner join Teams t ON Games.HomeTeamId = t.Id " +
                                            "inner join Teams f ON Games.VisitingTeamId = f.Id" +
                                            " where GameDate < @time", new { time });
                return View(data);
            }
        }

        public IActionResult Picks()
        {
            ViewData["Message"] = "View my picks";
            using (var db = new MySqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                DateTime currTime = DateTime.Now;
                string pastTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd hh:mm:ss");
                string futureTime = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd hh:mm:ss");
                var data = db.Query<Pick>("Select P2.Id, g.Id as 'GameId', ht.Name as 'HomeTeam', vt.Name as 'VisitingTeam', pt.Name as 'TeamPick', g.GameDate, g.HomeScore, g.VisitingScore, g.HomeTeamId, g.VisitingTeamId " +
                    "FROM Games g " +
                    "INNER JOIN Teams ht ON g.HomeTeamId = ht.Id " +
                    "INNER JOIN Teams vt ON g.VisitingTeamId = vt.Id " +
                    "Inner JOIN Picks P2 ON g.Id = P2.Game " +
                    "INNER JOIN Teams pt ON P2.Pick = pt.Id " +
                    "WHERE g.GameDate > @pastTime", new { pastTime } );

                for (int i = 0; i < data.Count(); ++i)
                {
                    Pick pick = data.ElementAt(i);
                    if (pick.GameDate > currTime)
                    {
                        pick.IsFuture = 1;
                    }
                    else
                    {
                        pick.IsFuture = 0;
                    }
                }

                return View(data);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Download()
        {
            //Response.Redirect();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
