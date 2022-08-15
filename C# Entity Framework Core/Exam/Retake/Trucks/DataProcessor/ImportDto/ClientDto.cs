using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace Trucks.DataProcessor.ImportDto
{
    [JsonObject]
    public class ClientDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }

        [JsonProperty("Trucks")]
        public int[] TrucksIds { get; set; }
    }
}
