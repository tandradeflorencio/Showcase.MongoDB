using Showcase.MongoDB.Models.Responses;

namespace Showcase.MongoDB.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> ListAsync();
    }
}
