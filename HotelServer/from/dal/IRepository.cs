using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL
{
    public interface IRepository<T>
    {
        List<T> Get();
        T GetById(int id);
        bool Post(T entity);
        T Put(int id , T entity);
        bool Delete(int id);
    }
}
