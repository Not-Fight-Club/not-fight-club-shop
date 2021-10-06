using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IRepo<T>
    {
        public Task<List<T>> ReadAll(Guid id); 
    }
}
