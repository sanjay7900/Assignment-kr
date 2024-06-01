using Assignment.Models.DataModels;
using Assignment.Models.ViewModels;

namespace Assignment.Services
{
    public interface IProductService
    {
        Task<int> GetAllProductsCount();
        Task<List<ProductDataModel>> GetAllProducts(List<int> ids);
        Task<List<ProductDataModel>> GetAllProducts(int pageNumber, int pageSize);
        Task<string> AddProduct(ProductViewModel model, int UserId);
        Task<string> BulkUpdate(BulkProductViewModel model, int IsUpdateOrDelete, int modifiedby);

    }
}
