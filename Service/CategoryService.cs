using ShopEase.Repository.Interface;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _categoryRepository.GetAll();
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        return await _categoryRepository.GetById(id);
    }

    public async Task AddCategory(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException("Category name must not be empty.");
        }

        await _categoryRepository.Add(category);
    }

    public async Task UpdateCategory(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException("Category name must not be empty.");
        }

        await _categoryRepository.Update(category);
    }

    public async Task DeleteCategory(Guid id)
    {
        var existingCategory = await _categoryRepository.GetById(id);
        if (existingCategory == null)
        {
            throw new ArgumentException("Category does not exist.");
        }

        await _categoryRepository.Delete(id);
    }
}
