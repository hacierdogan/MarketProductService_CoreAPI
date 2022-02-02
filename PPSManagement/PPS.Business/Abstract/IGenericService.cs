using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface IGenericService<T> where T:class
    {
        Task<List<T>> TGetAll();
        Task<T> TGetById(int id);
        Task<T> TCreate(T t);
        Task<T> TUpdate(T t);
        Task TDelete(int id);
    }
}
