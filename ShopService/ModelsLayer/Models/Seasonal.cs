using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.Models
{
    public partial class Seasonal
    {
        public Seasonal()
        {
            Products = new HashSet<Product>();
        }

        public int SeasonalId { get; set; }
        public string SeasonalName { get; set; }
        public DateTime SeasonalStartDate { get; set; }
        public DateTime SeasonalEndDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
