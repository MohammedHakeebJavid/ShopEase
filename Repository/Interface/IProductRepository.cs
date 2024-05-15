using System.Threading.Tasks;

namespace ShopEase.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}