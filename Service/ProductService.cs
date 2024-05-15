using ShopEase.Repository.Interface;
using ShopEase.Service.Interface;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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

         await _productRepository.AddProduct(product);
    }

    public async Task UpdateProduct(Product product)
    {
        // Validate product attributes before updating
        if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0 || product.Quantity < 0)
        {
            throw new ArgumentException("Invalid product attributes.");
        }

        await _productRepository.UpdateProduct(product);
    }

    public async Task DeleteProduct(Guid id)
    {
        var productToDelete =  _productRepository.GetProductById(id);
        if (productToDelete != null)
        {
            await _productRepository.DeleteProduct(id);
        }
        else
        {
            throw new ArgumentException("Product does not exist.");
        }
    }


}