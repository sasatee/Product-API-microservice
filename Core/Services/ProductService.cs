﻿using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.RepositoryContracts;
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
            List<Product?> product = (List<Product?>)await _productRepository.GetProductsByCondition(p => p.ProductName.StartsWith(filter.ToLowerInvariant()));


            return _mapper.Map<List<ProductResponse?>>(product);


        }

        public async Task<ProductResponse?> GetProductbyIdAsync(Guid id)
        {
             Product? product = (Product?)await _productRepository.GetProductByCondition(p=>p.ProductId == id);
            return _mapper.Map<ProductResponse?>(product);
        }

        public async Task<ProductResponse?> CreateProductAsync(ProductAddRequest? obj)
        {
               
          

                Product productEntity = _mapper.Map<Product>(obj); // map request body/payload "ProductAddRequest" to entity "Product" ===> ProductAddRequestMappingProfile


                Product? product = await _productRepository.AddProduct(productEntity);
                if (product is null) return null;
                

                return _mapper.Map<ProductResponse?>(product);
            

           
        }

        public async Task UpdateProductAsync(Guid id, ProductUpdateRequest? obj)
        {
            

        
            Product productEntity = _mapper.Map<Product>(obj);// map request body/payload "ProductUpdateRequest" to entity "Product" ===> ProductUpdateRequestMappingProfile

            await _productRepository.UpdateProduct(id, productEntity);
        }

        public async Task DeleteProductAsync(Guid Id)
        {
            await _productRepository.DeleteProduct(Id);
        }
    }
}
