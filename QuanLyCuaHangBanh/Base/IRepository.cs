using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public interface IRepository<T, D>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> getAll();
        List<D> getAllDto();

        T getByValue(object value);
    }
}
