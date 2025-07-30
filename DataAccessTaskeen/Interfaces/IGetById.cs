using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Interfaces
{
    public interface IGetById<T>
    {
        Task<T> GetByIdAsync(int id);

    }
}
