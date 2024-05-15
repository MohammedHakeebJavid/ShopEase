using ShopEase.Repository.Interface;

public class ProductRepository : IProductRepository
{

    private static List<Product> _products = new List<Product>(){ };
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await Task.FromResult(_products);
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await Task.FromResult(_products.FirstOrDefault(i => i.Id == id));
    }

    public async Task AddProduct(Product product)
    {
         product.Id = Guid.NewGuid();
        _products.Add(product);
        await Task.CompletedTask;
    }

    public async Task UpdateProduct(Product product)
    {
        var existingItem = _products.FirstOrDefault(i => i.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Name = product.Name;
            existingItem.Price = product.Price;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteProduct(Guid id)
    {
        var itemToRemove = _products.FirstOrDefault(i => i.Id == id);
        if (itemToRemove != null)
        {
            _products.Remove(itemToRemove);
        }
        await Task.CompletedTask;
    }
}