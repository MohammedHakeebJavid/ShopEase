using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ShopEase.Repository.Interface
{
    public interface ICategoryRepository 
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(Guid id);
        Task Add(Category entity);
        Task<ActionResult<Category>> Update(Category entity);
        Task Delete(Guid id);
    }
}
