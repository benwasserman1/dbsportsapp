using System;
namespace Bet.Models
{
    public class Game
    {

        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int HomeScore { get; set; }
        public int VisitingScore { get; set; }
        public string HomeTeam { get; set; }
        public string VisitingTeam { get; set; }
        public int HomeTeamId { get; set; }
        public int VisitingTeamId { get; set; }
        public int IsFuture { get; set; }

        public Game()
        {
        }
    }
}
