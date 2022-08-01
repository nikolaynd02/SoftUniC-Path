using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Common;

namespace ProductShop.DTOs.Categories
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
