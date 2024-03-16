using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Showcase.MongoDB.Models.Entities;
using Showcase.MongoDB.Repositories.Interfaces;
using Showcase.MongoDB.Settings;

namespace Showcase.MongoDB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerRepository(IOptions<ShowcaseDatabaseSettings> showcaseDatabaseSettings)
        {
            var mongoClient = new MongoClient(showcaseDatabaseSettings.Value.ConnectionString);

            var mongoDataBase = mongoClient.GetDatabase(showcaseDatabaseSettings.Value.DatabaseName);

            _customerCollection = mongoDataBase.GetCollection<Customer>(showcaseDatabaseSettings.Value.CustomersCollectionName);
        }

        public async Task<List<Customer>> ListAsync() => await _customerCollection.Find(_ => true).ToListAsync();
    }
}
