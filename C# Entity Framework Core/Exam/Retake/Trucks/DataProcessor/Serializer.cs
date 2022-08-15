using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            //ExportDespatcherDto[] dispatcherWithTrucks = context.Despatchers
            //    //.Include(d => d.Trucks)
            //    //.ThenInclude(t=>t.Despatcher)
            //    .Where(d => d.Trucks.Count > 0)
            //    .OrderByDescending(d => d.Trucks.Count)
            //    .ThenBy(d => d.Name)
            //    .ProjectTo<ExportDespatcherDto>()
            //    .ToArray();

            //foreach (var d in dispatcherWithTrucks)
            //{
            //    d.Trucks = d.Trucks.OrderBy(t => t.RegistrationNumber).ToArray();
            //}

            ExportDespatcherDto[] dispatcherWithTrucks = context
                .Despatchers
                .Include(d => d.Trucks)
                .ToArray()
                .Where(d => d.Trucks.Count > 0)
                .Select(d => new ExportDespatcherDto()
                {
                    Name = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckForDispatcherDto()
                        {
                            Make = t.MakeType.ToString(),
                            RegistrationNumber = t.RegistrationNumber
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()

                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.Name)
                .ToArray();




            XmlRootAttribute root = new XmlRootAttribute("Despatchers");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportDespatcherDto[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, dispatcherWithTrucks, namespaces);

            return writer.ToString().Trim();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsWithMostTrucks = context.Clients
                .Include(c =>c.ClientsTrucks)
                .ThenInclude(t => t.Truck)
                .ToArray()
                .Select(c => new 
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Select(t => new 
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType = t.Truck.CategoryType.ToString(),
                            MakeType = t.Truck.MakeType.ToString()
                        })
                        .Where(t =>t.TankCapacity>=capacity)
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .Where(c =>c.Trucks.Length > 0)
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clientsWithMostTrucks, Formatting.Indented);
        }
    }
}
