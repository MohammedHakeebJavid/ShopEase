namespace ShopEase.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task Add(Customer entity);
        Task Update(Customer entity);
        Task Delete(Guid id);
    }
}
