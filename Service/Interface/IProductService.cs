namespace ShopEase.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
