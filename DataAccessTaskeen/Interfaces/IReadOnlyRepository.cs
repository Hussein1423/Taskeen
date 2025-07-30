using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Interfaces
{
    public interface IReadOnlyRepository<T> : IGetById<T>, IGetAll<T>
    {
    }
}
