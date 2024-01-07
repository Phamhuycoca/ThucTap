using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Domain.Repositories
{
    public interface IRepo<T> where T : class, new()
    {
        IEnumerable<T> getAll();
        T GetbyId(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
