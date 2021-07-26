using EntityFramework_DesignTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetCustomersAsync();
        public Task<Customer> GetCustomerAsync(int id);
        public Task CreateAsync(Customer customer);
        public void Update(Customer customer);
        public void Remove(Customer customer);
    }
}
