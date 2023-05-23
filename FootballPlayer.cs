using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballProjectDzhansuDikmemehmed
{
    public class FootballPlayer : Person
    {
        public int Number { get; set; }
        public double Height { get; set; }
        public Team Team { get; set; }
        public FootballPlayer(string name, int age, int number, double height): base(name, age)
        {
            Number = number; 
            Height = height;
        }

    }
}
