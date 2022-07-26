using System;
using System.Collections.Generic;
using System.Linq;

namespace P._01
{
    class Program
    {
        //90/100
        static void Main(string[] args)
        {
            double[] arrivalTimes = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] departureTimes = Console.ReadLine().Split().Select(double.Parse).ToArray();

            List<Train> trains = new List<Train>();

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                trains.Add(new Train { Arrival = arrivalTimes[i], Departure = departureTimes[i] });
            }

            List<Train> orderedTrains = trains.OrderBy(x => x.Arrival).ToList();

            int platforms = 0;
            int maxPlatforms = 0;
            List<Train> arrivedTrains = new List<Train>();

            for (int i = 0; i < trains.Count; i++)
            {
                if (orderedTrains[i].Arrival > orderedTrains[i].Departure)
                {
                    platforms++;
                    if (platforms > maxPlatforms)
                    {
                        maxPlatforms = platforms;
                    }
                }

                if (arrivedTrains.Count > 0)
                {
                    while (arrivedTrains.Any(x => x.Departure <= orderedTrains[i].Arrival))
                    {
                        int currTrain = arrivedTrains.FindIndex(x => x.Departure <= orderedTrains[i].Arrival);
                        arrivedTrains.RemoveAt(currTrain);
                        platforms--;
                    }

                }
                arrivedTrains.Add(orderedTrains[i]);
                if (arrivedTrains.Any(x => x.Departure > orderedTrains[i].Arrival))
                {
                    platforms++;
                }

                if (platforms > maxPlatforms)
                {
                    maxPlatforms = platforms;
                }


            }

            Console.WriteLine(maxPlatforms);
        }
    }

    class Train
    {
        public double Arrival { get; set; }
        public double Departure { get; set; }
    }
}
