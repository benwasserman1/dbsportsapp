using System;
namespace Bet.Models
{
    public class Result
    {
        public string HomeTeam { get; set; }
        public string VisitingTeam { get; set; }
        public DateTime GameDate { get; set;  }
        public int HomeScore { get; set; }
        public int VisitingScore { get; set; }
        public string PickedTeam { get; set; }

        public Result()
        {
        }
    }
}
