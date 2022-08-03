using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            string rootName = "Plays";
            ImportPlayXmlDto[] playDtos = Deserialize<ImportPlayXmlDto[]>(xmlString, rootName);


            StringBuilder output = new StringBuilder();
            ICollection<Play> validPlays = new HashSet<Play>();
            foreach (var play in playDtos)
            {
                TimeSpan duration = TimeSpan.ParseExact(play.Duration, "c", CultureInfo.InvariantCulture);
                if (!IsValid(play) || duration.TotalHours < 1)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse(typeof(Genre), play.Genre, out var genreResult))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                validPlays.Add(new Play()
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = play.Rating,
                    Genre = (Genre)genreResult,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                });
                output.AppendLine(string.Format(SuccessfulImportPlay, play.Title,play.Genre,play.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            string rootName = "Casts";
            ImportCastXmlDto[] castDtos = Deserialize<ImportCastXmlDto[]>(xmlString, rootName);

            StringBuilder output = new StringBuilder();

            ICollection<Cast> validCasts = new HashSet<Cast>();
            foreach (var cast in castDtos)
            {
                if (!IsValid(cast))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                output.AppendLine(string.Format(SuccessfulImportActor, cast.FullName,
                    cast.IsMainCharacter ? "main" : "lesser"));
                validCasts.Add(new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                });
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ICollection<Theatre> validTheatres = new HashSet<Theatre>();
            StringBuilder output = new StringBuilder();

            var theatres = JsonConvert.DeserializeObject<ImportTheatreJsonDto[]>(jsonString);
            foreach (var theatre in theatres)
            {
                if (!IsValid(theatre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre validTheatre = new Theatre()
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director
                };

                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket validTicket = new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };
                    validTheatre.Tickets.Add(validTicket);
                }

                validTheatres.Add(validTheatre);
                output.AppendLine(string.Format(SuccessfulImportTheatre, validTheatre.Name,
                    validTheatre.Tickets.Count));
            }

            context.AddRange(validTheatres);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        //Helper methods for validation and xml
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
