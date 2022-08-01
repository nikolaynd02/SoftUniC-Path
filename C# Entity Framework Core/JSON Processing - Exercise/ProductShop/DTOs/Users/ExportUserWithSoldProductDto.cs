﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ProductShop.DTOs.Products;

namespace ProductShop.DTOs.Users
{
    [JsonObject]
    public class ExportUserWithSoldProductDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ICollection<ExportSoldProductDto> SoldProducts { get; set; }
    }
}
