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

        public override async Task<IList<TDto>> GetAllAsDto<TDto>(System.Linq.Expressions.Expression<Func<Product, TDto>> selector)
        {
            return await context.Products
                .Include(p => p.ProductUnits)
                .ThenInclude(pu => pu.Unit)
                .Include(p => p.ProductUnits)
                .ThenInclude(pu => pu.Inventory)
                .AsNoTracking()
                .Select(selector)
                .ToListAsync();
        }
        public override void Add(Product entity)
        {
            if (entity.Image != "" && entity.Image != null)
            {
                var cloudinary = CloudinaryConfig.GetCloudinaryClient();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(entity.Image)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                entity.Image = uploadResult.SecureUri.ToString();
            }

            base.Add(entity);
        }

        public override void Update(Product entity)
        {
            var oldEntity = context.Products.AsNoTracking().FirstOrDefault(p => p.ID == entity.ID);
            bool isNewImageUploaded = false;
            string oldImageUrl = oldEntity?.Image;

            // Chỉ upload nếu người dùng đã chọn ảnh mới từ máy
            if (!string.IsNullOrEmpty(entity.Image) &&
                !entity.Image.StartsWith("https://res.cloudinary.com"))
            {

                var cloudinary = CloudinaryConfig.GetCloudinaryClient();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(entity.Image)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                entity.Image = uploadResult.SecureUri.ToString();
            }
            else
            {
                // Nếu không đổi ảnh, giữ ảnh cũ
                entity.Image = oldEntity?.Image;
            }

            // Nếu đã upload ảnh mới, xóa ảnh cũ (nếu nó nằm trên cloudinary)
            if (isNewImageUploaded && !string.IsNullOrEmpty(oldImageUrl) &&
                oldImageUrl.StartsWith("https://res.cloudinary.com"))
            {
                var cloudinary = CloudinaryConfig.GetCloudinaryClient();

                // Tách public_id từ URL (giả định ảnh ở dạng: https://res.cloudinary.com/<cloud_name>/image/upload/v<version>/<public_id>.<ext>)
                Uri uri = new Uri(oldImageUrl);

                // Lấy phần path sau "upload/"
                string pathAfterUpload = uri.AbsolutePath.Split("/upload/")[1]; // "v1748229852/lh8zjmsny3nlzqmwehoo.png"

                // Bỏ version và đuôi ảnh
                string[] segments = pathAfterUpload.Split('/');

                // Nếu có version (bắt đầu bằng "v")
                if (segments[0].StartsWith("v"))
                {
                    string publicIdWithExtension = string.Join('/', segments.Skip(1)); // "lh8zjmsny3nlzqmwehoo.png"
                    string publicId = Path.ChangeExtension(publicIdWithExtension, null); // => "lh8zjmsny3nlzqmwehoo"

                    // Dùng để xóa:
                    var deletionParams = new DeletionParams(publicId);
                    var result = cloudinary.Destroy(deletionParams);
                }
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
