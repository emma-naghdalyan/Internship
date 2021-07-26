using EntityFramework_DesignTables.DataAccessLayer.Interfaces;
using EntityFramework_DesignTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.DataAccessLayer.Repositories
{
    public class ProductListRepository : IProductListRepository
    {
        private ApplicationDbContext _dbContext;

        public ProductListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
