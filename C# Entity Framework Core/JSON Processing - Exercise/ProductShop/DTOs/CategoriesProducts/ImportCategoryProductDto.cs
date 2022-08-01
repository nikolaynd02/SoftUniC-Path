using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.DTOs.CategoriesProducts
{
    [JsonObject]
    public class ImportCategoryProductDto
    {
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
    }
}
