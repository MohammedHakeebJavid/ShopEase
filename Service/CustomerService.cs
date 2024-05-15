using Microsoft.AspNetCore.Mvc;
using ShopEase.Repository.Interface;
using ShopEase.Service.Interface;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await _customerRepository.GetAll();
    }

    public async Task<Customer> GetCustomerById(Guid id)
    {
        return await _customerRepository.GetById(id);
    }

    public async Task AddCustomer(Customer customer)
    {
        // Validate customer attributes before adding
        if (string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.Email))
        {
            throw new ArgumentException("Customer name and email must not be empty.");
        }

        await _customerRepository.Add(customer);
    }

    public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
    {
        // Validate customer attributes before updating
        if (string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.Email))
        {
            throw new ArgumentException("Customer name and email must not be empty.");
        }

        return await _customerRepository.Update(customer);
    }

    public async Task DeleteCustomer(Guid id)
    {
        var existingCustomer = await _customerRepository.GetById(id);
        if (existingCustomer == null)
        {
            throw new ArgumentException("Customer does not exist.");
        }

        await _customerRepository.Delete(id);
    }
}
