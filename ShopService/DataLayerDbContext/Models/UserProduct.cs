using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayerDbContext.Models
{
    public partial class UserProduct
    {
        public int UserProductId { get; set; }
        public Guid? UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
