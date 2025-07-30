using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.Interfaces
{
    public interface IBasicCrudService<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<int> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
