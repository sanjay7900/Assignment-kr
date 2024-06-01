using Assignment.DBContextManager;
using Assignment.Extention;
using Assignment.Models.DataModels;
using Assignment.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace Assignment.Services
{
    public class ProductService:IProductService
    {
        private ProductAppContext _context;
        private readonly IMapper _mapper;

        public ProductService(ProductAppContext productAppContext,IMapper mapper)
        {
            _context = productAppContext; 
            _mapper=mapper; 
        }

        public async Task<List<ProductDataModel>> GetAllProducts(int pageNumber ,int pageSize)
        {
            var products = await _context.Products.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return products;
        }
        public async Task<List<ProductDataModel>> GetAllProducts(List<int> ids)
        {
            var products = await _context.Products.AsNoTracking().Where(p => ids.Contains(p.Id)).ToListAsync();
            return products;
        }
        public async Task<int> GetAllProductsCount()
        {
            var products = await _context.Products.AsNoTracking().CountAsync();
            return products;
        }


        public async Task<string> AddProduct(ProductViewModel model,int UserId)
        {
            try
            {
               await _context.Products.AddAsync(new ProductDataModel
                {
                    Name = model.Name,
                    ImagePath = model.ImageFile.SaveToFileAsync().Result,
                    Price = model.Price,
                    IsDelete = false,
                    CreatedDate = DateTime.Now,
                    CreatedBy = UserId,



                });
                await _context.SaveChangesAsync();
                return $"Product save successfully";
            }
            catch (Exception ex)
            {
                return $"Something went wrong while saving product";


            }

        }

        public async Task<string> BulkUpdate(BulkProductViewModel model,int IsUpdateOrDelete,int modifiedby)
        {
            try
            {
                string msg = string.Empty;
                var updatedProducts = model.Products.Select(s => new ProductDataModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    ImagePath = s.ImageFile.SaveToFileAsync().Result,
                    ModifiedBy = modifiedby,    
                    Modifieddate = DateTime.Now,    
                }).ToList();

                if (IsUpdateOrDelete == 1)
                {
                   
                    _context.Products.UpdateRange(updatedProducts);
                    _context.SaveChanges();

                    await _context.AuditLogs.AddRangeAsync(updatedProducts.Select(s => new AuditLog
                    {
                        Action = "Update",
                        Username = modifiedby,
                        Timestamp = DateTime.Now,
                        Details = $"Updated product {s.Name}"
                    }).ToList());
                    _context.SaveChanges();
                    msg = "products update successfully";
                }
                else
                {
                    _context.Products.RemoveRange(updatedProducts);
                   _context.SaveChanges();

                    await _context.AuditLogs.AddRangeAsync(updatedProducts.Select(s => new AuditLog
                    {
                        Action = "Delete",
                        Username = modifiedby,
                        Timestamp = DateTime.Now,
                        Details = $"Delete product {s.Name}"
                    }).ToList());

                    _context.SaveChanges();
                    msg = "products deleted successfully";

                }
              



               
               return $"{updatedProducts.Count} {msg}";
            }
            catch (Exception ex)
            {
                return "Something went wrong while updating product";
            }

           




        }
    }
}
