namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var albumsInfo = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .ToArray()
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseRate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        Writer = s.Writer.Name

                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToArray(),
                    TotalPrice = x.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();

            foreach(var album in albumsInfo)
            {
                output.AppendLine($"-AlbumName: {album.AlbumName}");
                output.AppendLine($"-ReleaseDate: {album.ReleaseRate}");
                output.AppendLine($"-ProducerName: {album.ProducerName}");
                output.AppendLine("-Songs:");

                int songCounter = 1;
                foreach(var song in album.Songs)
                {
                    output.AppendLine($"---#{songCounter++}");
                    output.AppendLine($"---SongName: {song.SongName}");
                    output.AppendLine($"---Price: {song.Price:f2}");
                    output.AppendLine($"---Writer: {song.Writer}");
                }
                output.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");

            }

            return output.ToString().Trim();
                
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder output = new StringBuilder();

            var songsInfo = context.Songs
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            int songCount = 1;
            foreach(var song in songsInfo)
            {
                output.AppendLine($"-Song #{songCount++}");
                output.AppendLine($"---SongName: {song.SongName}");
                output.AppendLine($"---Writer: {song.Writer}");
                output.AppendLine($"---Performer: {song.Performer}");
                output.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                output.AppendLine($"---Duration: {song.Duration:c}");
            }

            return output.ToString().Trim();
        }
    }
}
