using Core.Entities;
using Core.IRepository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Product?>> GetProductByCondition(string filter)
        {
            return await _context.Products.Where(p=>EF.Functions.Like(p.ProductName, $"%{filter}%")).ToListAsync();
        }

        public async Task<IEnumerable<Product?>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Guid Id, Product? product)
        {
            Product? existing = await _context.Products.FindAsync(Id);
            if(existing == null) return null;
            if (existing != null && product != null) 
            {


                existing.ProductName = product.ProductName;
                existing.UnitPrice = product.UnitPrice;
                existing.Category = product.Category;
                existing.QuantityInStock = product.QuantityInStock;

             

            }
            await _context.SaveChangesAsync();
            return existing;

        }
    }
}
