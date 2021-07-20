using EntityFramework_DesignTables.Entities;
using EntityFramework_DesignTables.Exceptions;
using EntityFramework_DesignTables.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var query = from customer in _dbContext.Customers
                        select customer;
            var customers = await query.ToListAsync();
            return customers;
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

        public async Task<List<CustomersFromAddress>> GetCustomersFromAsync(string address)
        {
            var query = from customers in _dbContext.Customers
                        join orderHistories in _dbContext.OrderHistories on customers.OrderHistoryId equals orderHistories.OrderHistoryId
                        where customers.Address.Contains(address)
                        //group customers by customers.CustomerId into customersGroup
                        //orderby customersGroup.Key
                        //select customersGroup;
                        orderby customers.OrderHistoryId
                        select new CustomersFromAddress
                        {
                            CustomerId = customers.CustomerId,
                            Address = customers.Address,
                            UnitSold = orderHistories.UnitSold
                        };
            var listFrom = await query.ToListAsync();
            return listFrom;
        }

        public async Task UpdateCustomerAddressAsync(int customerId, string address)
        {
            var customer = await GetCustomerAsync(customerId);
            customer.Address = address;
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerIn = await GetCustomerAsync(customer.CustomerId);
            customerIn.OrderHistoryId = customer.OrderHistoryId;
            customerIn.Name = customer.Name;
            customerIn.Address = customer.Address;
            _dbContext.Customers.Update(customerIn);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int customerId)
        {
            var customer = await GetCustomerAsync(customerId);
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}