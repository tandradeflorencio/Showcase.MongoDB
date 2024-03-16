using Showcase.MongoDB.Models.Entities;

namespace Showcase.MongoDB.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> ListAsync();
    }
}
