namespace ShopEase.Repository.Interface
{
    public interface ICategoryRepository 
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(Guid id);
        Task Add(Category entity);
        Task Update(Category entity);
        Task Delete(Guid id);
    }
}
