using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTeamDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+$")]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [StringLength(40,MinimumLength = 2)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required]
        [Range(1,int.MaxValue)]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; }
    }
}
