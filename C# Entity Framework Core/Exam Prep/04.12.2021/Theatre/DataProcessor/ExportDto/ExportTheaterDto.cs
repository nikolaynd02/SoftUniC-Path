using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTheaterDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Halls")]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("TotalIncome")]
        public decimal TotalIncome { get; set; }
        [JsonProperty("Tickets")]
        public ExportTicketDto[] Tickets { get; set; }
    }
}
