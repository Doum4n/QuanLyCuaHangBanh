using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        Task<IList<TEntity>> GetAll();
        Task<TEntity?> GetByValue(object value);

        Task<IList<TDto>> GetAllAsDto<TDto>(Expression<Func<TEntity, TDto>> selector);
    }
}
