using EntityFramework_DesignTables.DataAccessLayer.Interfaces;
using EntityFramework_DesignTables.Entities;
using EntityFramework_DesignTables.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Customer customer)
        {
            if (customer==null)
            {
                throw new NullReferenceException();
            }
            await _dbContext.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                throw new NotFoundException("The customer is not found ... ");
            }
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var query = from customer in _dbContext.Customers
                        select customer;
            var customers = await query.ToListAsync();
            return customers;
        }

        public void Remove(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }
    }
}
