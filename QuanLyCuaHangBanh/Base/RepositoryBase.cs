using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;

namespace QuanLyCuaHangBanh.Base
{
    public abstract class RepositoryBase<TEntity>(QLCHB_DBContext context) : IRepository<TEntity> where TEntity : class
    {
        protected readonly QLCHB_DBContext context = context;

        public virtual void Add(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Delete(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void Update(TEntity entity)
        {
            // Kiểm tra xem entity có đang được theo dõi trong context không
            try
            {
                var entityId = (int)entity.GetType().GetProperty("ID")!.GetValue(entity)!;
                var trackedEntity = context.Set<TEntity>().Local.FirstOrDefault(e =>
                    (int)e.GetType().GetProperty("ID")!.GetValue(e)! == entityId
                );

                if (trackedEntity != null)
                {
                    // Nếu entity đã được theo dõi, thay đổi các giá trị
                    context.Entry(trackedEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    // Nếu entity chưa được theo dõi, gắn nó vào context và đánh dấu là sửa đổi
                    context.Set<TEntity>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
            
        }

        public virtual async Task<TEntity?> GetByValue(object value)
        {
            try
            {
                return await context.Set<TEntity>().FindAsync(value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual Task<IList<TEntity>> GetAll()
        {
            try
            {
                return Task.FromResult<IList<TEntity>>(context.Set<TEntity>().ToList());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<IList<TDto>> GetAllAsDto<TDto>(Expression<Func<TEntity, TDto>> selector)
        {
            try{
                   return await context.Set<TEntity>()
                         .AsNoTracking() // Thường dùng cho các truy vấn chỉ đọc
                         .Select(selector) // Áp dụng phép chiếu (projection) ở đây
                         .ToListAsync();  // Rồi mới lấy dữ liệu
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}