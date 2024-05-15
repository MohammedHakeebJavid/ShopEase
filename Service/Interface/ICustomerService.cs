using Microsoft.AspNetCore.Mvc;

namespace ShopEase.Service.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task AddCustomer(Customer customer);
        Task<ActionResult<Customer>> UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
    }
}
