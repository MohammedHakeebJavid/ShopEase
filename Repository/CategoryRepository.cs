using Microsoft.AspNetCore.Mvc;
using ShopEase.Repository.Interface;

public class CategoryRepository : ICategoryRepository
{
    private static List<Category> _categories = new List<Category>() { };

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await Task.FromResult(_categories);
    }

    public async Task<Category> GetById(Guid id)
    {
        return await Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));
    }

    public async Task Add(Category entity)
    {
        entity.Id = Guid.NewGuid();
        _categories.Add(entity);
        await Task.CompletedTask;
    }

    public async Task<ActionResult<Category>> Update(Category entity)
    {
        var existingCategory = await GetById(entity.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = entity.Name;
            existingCategory.Description = entity.Description;
        }
        return existingCategory;
    }

    public async Task Delete(Guid id)
    {
        var categoryToRemove = await GetById(id);
        if (categoryToRemove != null)
        {
            _categories.Remove(categoryToRemove);
        }
        await Task.CompletedTask;
    }
}
