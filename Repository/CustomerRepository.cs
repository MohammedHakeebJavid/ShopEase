using Microsoft.AspNetCore.Mvc;
using ShopEase.Repository.Interface;

public class CustomerRepository : ICustomerRepository
{
    private static List<Customer> _customers = new List<Customer>() { };

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await Task.FromResult(_customers);
    }

    public async Task<Customer> GetById(Guid id)
    {
        return await Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));
    }

    public async Task Add(Customer entity)
    {
        entity.Id = Guid.NewGuid();
        _customers.Add(entity);
        await Task.CompletedTask;
    }

    public async Task<ActionResult<Customer>> Update(Customer entity)
    {
        var existingCustomer = await GetById(entity.Id);
        if (existingCustomer != null)
        {
            existingCustomer.Name = entity.Name;
            existingCustomer.Email = entity.Email;
            existingCustomer.Address = entity.Address;
            existingCustomer.ContactNumber = entity.ContactNumber;
        }
        return existingCustomer;
    }

    public async Task Delete(Guid id)
    {
        var customerToRemove = await GetById(id);
        if (customerToRemove != null)
        {
            _customers.Remove(customerToRemove);
        }
        await Task.CompletedTask;
    }
}