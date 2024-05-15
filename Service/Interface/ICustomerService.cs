namespace ShopEase.Service.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
    }
}
