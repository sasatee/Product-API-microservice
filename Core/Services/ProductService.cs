using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.IRepository;
using Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
           _productRepository = productRepository;
            _mapper = mapper;
        }
        

        public async Task<List<ProductResponse?>> GetAllProductsAsync()
        {
            List<Product> products = (List<Product>)await _productRepository.GetProducts();


     
            return _mapper.Map<List<ProductResponse?>>(products);
        }

        public async Task<List<ProductResponse?>> GetProductByConditionAsync(string filter)
        {
            List<Product?> product = (List<Product?>) await _productRepository.GetProductByCondition(filter);


            return _mapper.Map<List<ProductResponse?>>(product);


        }
    }
}
