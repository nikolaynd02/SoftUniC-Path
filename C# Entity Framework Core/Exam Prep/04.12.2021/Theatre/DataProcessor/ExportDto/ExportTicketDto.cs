using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTicketDto
    {
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        public sbyte RowNumber { get; set; }
    }
}
