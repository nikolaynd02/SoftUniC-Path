using System;
using System.Collections.Generic;

namespace P01._Ranking
{
    class User
    {
        public string Name { get; set; }

        public double Points { get; set; }
    }
    class Contest
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = string.Empty;

            while((input=Console.ReadLine())!= "end of contests")
            {
                string[] contestInfo = input.Split(":");
                string contestName = contestInfo[0];
                string contestPass = contestInfo[1];
                contests[contestName] = contestPass;
            }

            //finish below
            Dictionary<string, double> usersTotalPoints = new Dictionary<string, double>();

            List<Contest> usersContests = new List<Contest>();

            while((input = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = input.Split("=>");
                string userContest = userInfo[0];
                string userPass = userInfo[1];
                string userName = userInfo[2];
                double userPoints = double.Parse(userInfo[3]);

                User newUser = new User()
                {
                    Name = userName,
                    Points = userPoints
                };

                if(contests.ContainsKey(userContest))
                {
                    if (contests[userContest] == userPass)
                    {
                        int contestIndex = usersContests.FindIndex(x => x.Name == userContest);
                        if (contestIndex < 0)
                        {
                            Contest newContest = new Contest()
                            {
                                Name = userContest,
                                Users = new List<User> { newUser }
                            };
                            usersContests.Add(newContest);
                            //usersTotalPoints[userName] = userPoints;
                        }
                        else
                        {
                            int userIndex = usersContests[contestIndex].Users.FindIndex(x => x.Name == userName);
                            if (userIndex < 0)
                            {
                                usersContests[contestIndex].Users.Add(newUser);
                            }
                            else
                            {
                                if (usersContests[contestIndex].Users[userIndex].Points < userPoints)
                                {
                                    usersContests[contestIndex].Users[userIndex].Points = userPoints;
                                }
                            }
                        }

                    }
                }
            }
            


        }
    }
}
