using DataAccessTaskeen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Base
{
    public interface IMutableRepository<T> : IReadOnlyRepository<T>
    {
        Task<int?> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }

}
