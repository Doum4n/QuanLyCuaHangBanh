using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace QuanLyCuaHangBanh.Repositories
{
    public class ProductRepo(QLCHB_DBContext context) : RepositoryBase<Product>(context)
    {
        public override IList<TDto> GetAllAsDto<TDto>(Func<Product, TDto> converter)
        {
            return context.Products
                .AsNoTracking()
                .AsSplitQuery() // nếu có nhiều include
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Include(p => p.ProductUnits)
                .ThenInclude(pu => pu.Unit)
                .Select(converter)
                .ToList();

        }

        public override void Add(Product entity)
        {
            //if (entity.Image != "" && entity.Image != null)
            //{
            //    var cloudinary = CloudinaryConfig.GetCloudinaryClient();
            //    var uploadParams = new ImageUploadParams()
            //    {
            //        File = new FileDescription(entity.Image)
            //    };
            //    var uploadResult = cloudinary.Upload(uploadParams);
            //    entity.Image = uploadResult.SecureUri.ToString();
            //}

            base.Add(entity);
        }

        public override void Update(Product entity)
        {
            if(entity.Image != "" && !entity.Image.Contains("https://res.cloudinary.com"))
            {
                var cloudinary = CloudinaryConfig.GetCloudinaryClient();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(entity.Image)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                entity.Image = uploadResult.SecureUri.ToString();
            }

            base.Update(entity);
        }

        public void DeleteById(int ID)
        {
            var productUnits = context.ProductUnits.Where(pu => pu.ProductID == ID).ToList();
            foreach (var productUnit in productUnits)
            {
                context.Inventories.RemoveRange(context.Inventories.Where(inv => inv.ProductUnitID == productUnit.ID));
            }
            context.ProductUnits.RemoveRange(productUnits);
            context.Products.Remove(context.Products.Find(ID)!);
            context.SaveChanges();
        }

    }
}
