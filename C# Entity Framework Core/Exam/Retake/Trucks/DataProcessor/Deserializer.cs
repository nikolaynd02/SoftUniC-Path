using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Despatchers");
            XmlSerializer serializer = new XmlSerializer(typeof(DespatcherDto[]), root);

            using StringReader reader = new StringReader(xmlString);
            DespatcherDto[] despatcherDtos = (DespatcherDto[])serializer.Deserialize(reader);


            StringBuilder output = new StringBuilder();

            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (var dto in despatcherDtos)
            {
                if (!IsValid(dto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(dto.Position))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = dto.Name,
                    Position = dto.Position
                };

                foreach (var truckDto in dto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!Enum.TryParse(typeof(CategoryType), truckDto.CategoryType, out object validCategoryType))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!Enum.TryParse(typeof(MakeType), truckDto.MakeType, out object validMakeType))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }


                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)validCategoryType,
                        MakeType = (MakeType)validMakeType
                    };

                    despatcher.Trucks.Add(truck);
                }

                validDespatchers.Add(despatcher);

                output.AppendLine(
                    $"Successfully imported despatcher - {despatcher.Name} with {despatcher.Trucks.Count} trucks.");
            }
            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return output.ToString().Trim();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ClientDto[] clientDtos = JsonConvert.DeserializeObject<ClientDto[]>(jsonString);

            StringBuilder output = new StringBuilder();

            ICollection<Client> validClients = new HashSet<Client>();

            int[] validTruckIds = context.Trucks.Select(t => t.Id).ToArray();

            foreach (var dto in clientDtos)
            {
                if (!IsValid(dto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (dto.Type == "usual")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Client validClient = new Client()
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Type = dto.Type
                };

                foreach (var id in dto.TrucksIds.Distinct())
                {
                    if (!validTruckIds.Contains(id))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    validClient.ClientsTrucks.Add(new ClientTruck()
                    {
                        TruckId = id,
                        Client = validClient
                    });
                }

                output.AppendLine(
                    $"Successfully imported client - {validClient.Name} with {validClient.ClientsTrucks.Count} trucks.");
                validClients.Add(validClient);
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
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
    }
}
