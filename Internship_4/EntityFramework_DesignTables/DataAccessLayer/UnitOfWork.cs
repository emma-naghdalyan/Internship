using EntityFramework_DesignTables.DataAccessLayer.Interfaces;
using EntityFramework_DesignTables.DataAccessLayer.Repositories;
using EntityFramework_DesignTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository Customers
        {
            get
            {
                return new CustomerRepository(_dbContext);
            }
            private set { }
        }

        public IProductRepository Products
        {
            get
            {
                return new ProductRepository(_dbContext);
            }
            private set { }
        }

        public IProductListRepository ProductLists
        {
            get
            {
                return new ProductListRepository(_dbContext);
            }
            private set { }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
