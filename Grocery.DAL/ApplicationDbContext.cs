using Grocery.common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<CategoryEntity> CategoryTable { get; set; }
        public DbSet<ProductEntity> ProductTable { get; set; }
        public DbSet<StockEntity> StockTable { get; set; }
        public DbSet<BrandEntity> BrandTable { get; set; }
        public object UserEntity { get; set; }
    }
}
