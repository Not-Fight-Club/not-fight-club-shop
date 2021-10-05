using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class ShopRepo : IRepo<ShopRepo>
    {
        public List<ShopRepo> ReadAll(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
