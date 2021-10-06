using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
    public class ViewUserProduct
    {

        public int UserProductId { get; set; }
        public Guid? UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
    
}
