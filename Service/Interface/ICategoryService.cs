using Microsoft.AspNetCore.Mvc;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(Guid id);
    Task AddCategory(Category category);
    Task<ActionResult<Category>> UpdateCategory(Category category);
    Task DeleteCategory(Guid id);
}