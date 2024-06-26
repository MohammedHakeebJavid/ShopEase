﻿using ShopEase.Repository.Interface;
using ShopEase.Service.Interface;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository= categoryRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productRepository.GetAllProducts();
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _productRepository.GetProductById(id);
    }

    public async Task AddProduct(Product product)
    {
        // Validate product attributes before adding
        if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0 || product.Quantity < 0)
        {
            throw new ArgumentException("Invalid product attributes.");
        }
        var category=await _categoryRepository.GetById(product.CategoryId);
        if (category==null)
        {
            throw new ArgumentException("Category not exist");
        }
         await _productRepository.AddProduct(product);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        // Validate product attributes before updating
        if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0 || product.Quantity < 0)
        {
            throw new ArgumentException("Invalid product attributes.");
        }
        var category = await _categoryRepository.GetById(product.CategoryId);
        if (category == null)
        {
            throw new ArgumentException("Category not exist");
        }
        return await _productRepository.UpdateProduct(product);
    }

    public async Task DeleteProduct(Guid id)
    {
        var productToDelete =await  _productRepository.GetProductById(id);
        if (productToDelete == null)
        {
            throw new ArgumentException("Customer does not exist.");
        }
        await _productRepository.DeleteProduct(id);
    }
}