using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Teamwork_Projects
{    
    class Team
    {
        public string Creator { get; set; }

        public string TeamName { get; set; }

        public List<string> Members = new List<string>();        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for(int i = 0; i < numOfTeams; i++)
            {
                string[] info = Console.ReadLine().Split("-");

                string creator = info[0];
                string teamName = info[1];
                
                if(teams.Any(n => n.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if(teams.Any(c => c.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team newTeam = new Team()
                    {
                        Creator = creator,
                        TeamName = teamName
                    };
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    teams.Add(newTeam);
                }
            }

            string[] input = Console.ReadLine().Split("->");

            while(input[0]!="end of assignment")
            {
                string user = input[0];
                string team = input[1];

                Team teamToJoin = teams.FirstOrDefault(t => t.TeamName == team);

                if (teamToJoin != null)
                {
                    if (teams.Any(t => t.Members.Contains(user) || t.Creator == user))
                    {
                        Console.WriteLine($"Member {user} cannot join team {team}!");
                    }
                    else
                    {
                        teamToJoin.Members.Add(user);
                    }
                }
                else
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }


                input = Console.ReadLine().Split("->");
            }

            List<Team> validTeams =
                teams.Where(t => t.Members.Count > 0)
                .OrderByDescending(m => m.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();

            List<Team> invalidTeams =
                teams.Where(t => t.Members.Count == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            PrintValidTeams(validTeams);

            PrintInvalidTeams(invalidTeams);
        }

        static void PrintValidTeams(List<Team> validTeam)
        {
            foreach(Team currTeam in validTeam)
            {
                Console.WriteLine(currTeam.TeamName);
                Console.WriteLine($"- {currTeam.Creator}");

                foreach(string member in currTeam.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }

        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");

            foreach(Team currteam in invalidTeams)
            {
                Console.WriteLine(currteam.TeamName);
            }
        }


        //static bool IsAlreadyMemberOfTeam(List<Team> teams, string userName)
        //{
        //    foreach(Team team in teams)
        //    {
        //        if (team.Members.Contains(userName))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
