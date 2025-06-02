using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product?>> GetProducts();
        Task<IEnumerable<Product?>> GetProductByCondition(string filter);
         
        Task<Product?> GetProductById(Guid id);
        Task<Product?> AddProduct(Product? product);

        Task<Product?> UpdateProduct(Guid Id ,Product? product); 
        Task DeleteProduct(Guid Id);



    }
}
