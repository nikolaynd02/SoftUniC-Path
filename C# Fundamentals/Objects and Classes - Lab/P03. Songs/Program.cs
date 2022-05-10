using System;
using System.Collections.Generic;

namespace P03._Songs
{
    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();


            for(int i = 0; i < numberOfSongs; i++)
            {
                string[] inputSong = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries);

                Song newSong = new Song()
                {
                    TypeList = inputSong[0],
                    Name = inputSong[1],
                    Time = inputSong[2],

                };

                songs.Add(newSong);
            }

            string printCmd = Console.ReadLine();

            if (printCmd == "all")
            {
                foreach(Song songName in songs)
                {
                    Console.WriteLine(songName.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.FindAll(currSong => currSong.TypeList == printCmd);

                foreach(Song songName in filteredSongs)
                {
                    Console.WriteLine(songName.Name);
                }
            }

        }
    }
}
