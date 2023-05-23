using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballProjectDzhansuDikmemehmed
{
    public class Game
    {
        public Team TeamFirst { get; set; }
        public Team TeamSecond { get; set; }
        public Referee Referee { get; set; }
        public Person[] AssistantReferee { get; set; }
        public Goal[] Goal { get; set; }
        public string Result { get; set; }
        public string Winner { get; set; }

        public Game(Team team1, Team team2, Referee referee, Person[] assistantReferees)
        {
            TeamFirst = team1;
            TeamSecond = team2;
            Referee = referee;
            AssistantReferee = assistantReferees;
        }
        public void AddGoal(int minute, FootballPlayer player)
        {
            Goal newGoal = new Goal(minute, player);
            if (Goal == null)
            {
                Goal = new Goal[]
                { 
                    newGoal
                };
            }
            else
            {
                Goal[] updatedGoals = new Goal[Goal.Length + 1];
                Array.Copy(Goal, updatedGoals, Goal.Length);
                updatedGoals[Goal.Length] = newGoal;
                Goal = updatedGoals;
            }
        }
        public void Start()
        {
            Console.WriteLine("Започва играта между отборите на " + TeamFirst.Coach.Name + " и " + TeamSecond.Coach.Name + ".");
            Console.WriteLine("Съдия на мача: " + Referee.Name);
            Console.WriteLine("Помощни съдии: " + AssistantReferee[0].Name + ", " + AssistantReferee[1].Name);
            Console.WriteLine("Играчи на отбора на " + TeamFirst.Coach.Name + ":");
            foreach (var player in TeamFirst.Players)
            {
                Console.WriteLine(player.Name + " - " + player.Number);
            }
            Console.WriteLine("Играчи на отбора на " + TeamSecond.Coach.Name + ":");
            foreach (var player in TeamSecond.Players)
            {
                Console.WriteLine(player.Name + " - " + player.Number);
            }
            Console.WriteLine("Играта започва!");
        }
        public FootballPlayer GetRandomPlayer()
        {
            Random random = new Random();
            int teamIndex = random.Next(2);
            Team selectedTeam = (teamIndex == 0) ? TeamFirst : TeamSecond;

            int playerIndex = random.Next(selectedTeam.Players.Length);
            FootballPlayer selectedPlayer = selectedTeam.Players[playerIndex];
            selectedPlayer.Team = selectedTeam; 

            return selectedPlayer;
        }
        public void Finish()
        {
            int goalsTeam1 = 0;
            int goalsTeam2 = 0;

            if (Goal != null)
            {
                foreach (var goal in Goal)
                {
                    if (goal.Player.Team == TeamFirst)
                    {
                        goalsTeam1++;
                    }
                    else if (goal.Player.Team == TeamSecond)
                    {
                        goalsTeam2++;
                    }
                }
            }

            if (goalsTeam1 > goalsTeam2)
            {
                Winner = "Отбор 1";
            }
            else if (goalsTeam1 < goalsTeam2)
            {
                Winner = "Отбор 2";
            }
            else
            {
                Winner = "Равенство";
            }
            Result = $"{goalsTeam1}:{goalsTeam2}";
        }
    }
}
