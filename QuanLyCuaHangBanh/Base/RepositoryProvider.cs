using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly IServiceProvider _services;

        public RepositoryProvider(IServiceProvider services)
        {
            _services = services;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return _services.GetService(typeof(IRepository<T>)) as IRepository<T>
                   ?? throw new InvalidOperationException($"Repository for {typeof(T).Name} not found");
        }
    }

}
