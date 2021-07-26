using EntityFramework_DesignTables.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer
{
    public interface IUnitOfWork
    {
        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }
        public IProductListRepository ProductLists { get; }
        public Task Commit();
    }
}
