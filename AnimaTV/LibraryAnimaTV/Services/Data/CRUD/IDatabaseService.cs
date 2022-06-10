using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Core.Services.Data.CRUD
{
    public interface IDatabaseService<T> where T: class
    {
        IEnumerable<T> Get(string id);
        T Delete(string id);
        T Put(string id);
        T Create(T target);
    }
}
