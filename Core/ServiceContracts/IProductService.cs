using Core.DTOs;


namespace Core.ServiceContracts
{
    public interface IProductService
    {

        Task<List<ProductResponse?>> GetAllProductsAsync();

        Task<List<ProductResponse?>> GetProductByConditionAsync(string filter);
    }
}
