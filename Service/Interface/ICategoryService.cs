public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(Guid id);
    Task AddCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(Guid id);
}