using Microsoft.AspNetCore.Mvc;

namespace ShopEase.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task Add(Customer entity);
        Task<ActionResult<Customer>> Update(Customer entity);
        Task Delete(Guid id);
    }
}
