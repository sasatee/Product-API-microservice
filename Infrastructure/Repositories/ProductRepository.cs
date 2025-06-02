using Core.Entities;
using Core.RepositoryContracts;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> AddProduct(Product? product)
        {
            if(product != null)
            {
                await _context.Products.AddAsync(product);
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Guid Id)
        {
           Product? existing = await _context.Products.FindAsync(Id);

            if (existing != null)
            {

                 _context.Products.Remove(existing);
               await _context.SaveChangesAsync();


            }
           
        }

        public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _context.Products.FirstOrDefaultAsync(conditionExpression); 
        }

        



        public async Task<IEnumerable<Product?>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _context.Products.Where(conditionExpression).ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Guid Id, Product? product)
        {
            Product? existing = await _context.Products.FirstOrDefaultAsync(temp => temp.ProductId == product.ProductId);
            if(existing is null) return null;
            if (existing is not null && product is not null) 
            {


                existing.ProductName = product.ProductName;
                existing.UnitPrice = product.UnitPrice;
                existing.Category = product.Category;
                existing.QuantityInStock = product.QuantityInStock;


                 _context.Update(existing);
            }
           
            await _context.SaveChangesAsync();
            return existing;

        }
    }
}
