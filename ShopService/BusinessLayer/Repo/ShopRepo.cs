using BusinessLayer.Interface;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class ShopRepo : IRepo
    {
        

        List<Product> IRepo.ReadAll(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
