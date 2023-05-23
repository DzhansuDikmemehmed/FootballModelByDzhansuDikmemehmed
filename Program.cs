using FootballProjectDzhansuDikmemehmed;
using System;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FootballPlayer[] players1 = new FootballPlayer[]
        {
            new Goalkeeper("Георги", 23, 1, 181),
            new Defender("Йосиф", 25, 2, 177),
            new Midfield("Ивайло", 24, 3, 188),
            new Striker("Станимир", 22, 4, 186)
        };

            Coach coach1 = new Coach("Треньор Иванов", 43);
            Team team1 = new Team(coach1, players1);

            FootballPlayer[] players2 = new FootballPlayer[]
            {
            new Goalkeeper("Божидар", 22, 1, 191),
            new Defender("Ангел", 26, 2, 190),
            new Midfield("Красимир", 23, 3, 185),
            new Striker("Кристиян", 25, 4, 195)
            };

            Coach coach2 = new Coach("Треньор Бобев", 45);
            Team team2 = new Team(coach2, players2);

            Referee referee = new Referee("Съдия Каракачанов", 35);
            Person[] assistantReferees = new Person[]
            {
            new Person("Помощен съдия Лалев", 30),
            new Person("Помощен съдия Бизов", 32)
            };

            Game game = new Game(team1, team2, referee, assistantReferees);

            game.Start();

            Random random = new Random();
            int totalMinutes = 90;

            for (int currentMinute = 1; currentMinute <= totalMinutes; currentMinute++)
            {
                int eventProbability = random.Next(1, 101);

                if (eventProbability <= 30)
                {
                    FootballPlayer scorer = game.GetRandomPlayer();
                    scorer.Team = (scorer.Team == game.TeamFirst) ? game.TeamFirst : game.TeamSecond;
                    game.AddGoal(currentMinute, scorer);
                    Console.WriteLine("Гол за " + scorer.Name + " в " + currentMinute + " минута.");

                }
                else if (eventProbability <= 60)
                {
                    FootballPlayer player = game.GetRandomPlayer();
                    Console.WriteLine("Жълта карта за " + player.Name + " в " + currentMinute + " минута.");
                }
                else if (eventProbability <= 75)
                {
                    FootballPlayer player = game.GetRandomPlayer();
                    Console.WriteLine("Червена карта за " + player.Name + " в " + currentMinute + " минута.");
                }
                else
                {
                    Console.WriteLine("Няма събитие в " + currentMinute + " минута.");
                }
            }

            game.Finish();
            Console.WriteLine("Резултат:");
            Console.WriteLine("Отбор 1: " + game.TeamFirst.Coach.Name + ": " + game.Result);
            Console.WriteLine("Отбор 2: " + game.TeamSecond.Coach.Name + ": " + game.Result);
            Console.WriteLine("Победител: " + game.Winner);
            
        }
    }
}