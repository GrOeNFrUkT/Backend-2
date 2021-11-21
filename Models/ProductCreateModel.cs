using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; }

        public string Short { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = "";

        public int SubCategoryId { get; set; }
    }
}
