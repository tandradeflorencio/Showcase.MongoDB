using Showcase.MongoDB.Models.Responses;
using Showcase.MongoDB.Repositories;
using Showcase.MongoDB.Services.Interfaces;

namespace Showcase.MongoDB.Services
{
    public class CustomerService(CustomerRepository customerRepository) : ICustomerService
    {
        public async Task<List<CustomerResponse>> ListAsync()
        {
            var customers = await customerRepository.ListAsync();
            var customerResponse = new List<CustomerResponse>(customers.Count);

            foreach (var customer in customers)
            {
                customerResponse.Add(new CustomerResponse(customer.Id, customer.Name)); 
            }

            return customerResponse;
        }
    }
}
