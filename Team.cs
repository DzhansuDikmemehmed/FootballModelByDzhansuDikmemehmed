using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballProjectDzhansuDikmemehmed
{
   public class Team
    {
        public Coach Coach { get; set; }
        public FootballPlayer[] Players { get; set; }
        public Team(Coach coach, FootballPlayer[] players)
        {
            Coach = coach;
            Players = players;
        }
        public double AveragePlayerAge()
        {
            return Players.Average(player => player.Age);
        }
    }
}
