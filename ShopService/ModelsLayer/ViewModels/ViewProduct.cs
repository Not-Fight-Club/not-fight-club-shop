using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.ViewModels
{
    public class ViewProduct
    {
        public ViewProduct()
        {
            UserProducts = new HashSet<UserProduct>();
        }

        public int ProductId { get; set; }
        public int? SeasonalId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductDiscount { get; set; }

        public virtual Seasonal Seasonal { get; set; }
        public virtual ICollection<UserProduct> UserProducts { get; set; }
    }
}
