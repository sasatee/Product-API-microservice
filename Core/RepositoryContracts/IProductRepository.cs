using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoryContracts
{

    /// <summary>
    /// Represents a repository for manage "products" table
    /// </summary>
    public interface IProductRepository
    {

        Task<IEnumerable<Product?>> GetProducts();




        ///// <summary>
        ///// Retrieve all products based on the specified condition asynchronously
        ///// </summary>
        ///// <param name="conditionExpression">The condition to filter products</param>
        ///// <returns>Returning a collection of the matching products or null if not found</returns>
        Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);



        /// <summary>
        /// Retrieves a single products based on the specified condition asynchronously
        /// </summary>
        /// <param name="conditionExpression">The condition to filter products</param>
        /// <returns>Returns a single products or null if not found </returns>
        Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);

   
        Task<Product?> AddProduct(Product? product);

        Task<Product?> UpdateProduct(Guid Id ,Product? product); 
        Task DeleteProduct(Guid Id);



    }
}
