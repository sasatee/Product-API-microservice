using Core.DTOs;


namespace Core.ServiceContracts
{
    public interface IProductService
    {

        Task<List<ProductResponse?>> GetAllProductsAsync();

        Task<List<ProductResponse?>> GetProductByConditionAsync(string filter);

        Task<ProductResponse?> GetProductbyIdAsync(Guid id);

        Task<ProductResponse?> CreateProductAsync(ProductAddRequest? obj);

        Task UpdateProductAsync(Guid Id,ProductUpdateRequest? obj);

        Task DeleteProductAsync(Guid Id);
    }
}
