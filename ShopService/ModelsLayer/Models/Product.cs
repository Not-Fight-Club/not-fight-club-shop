using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.Models
{
    public partial class Product
    {
        public Product()
        {
            UserProducts = new HashSet<UserProduct>();
        }

        public int ProductId { get; set; }
        public int? SeasonalId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductDiscount { get; set; }

        public int? CategoryId { get; set; }


        public virtual Category Category { get; set; }
        public virtual Seasonal Seasonal { get; set; }
        public virtual ICollection<UserProduct> UserProducts { get; set; }
    }
}
