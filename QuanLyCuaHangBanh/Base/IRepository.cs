using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;

namespace QuanLyCuaHangBanh.Base
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IList<TEntity> GetAll();
        TEntity GetByValue(object value);

        IList<TDto> GetAllAsDto<TDto>(Func<TEntity, TDto> converter);
    }
}
