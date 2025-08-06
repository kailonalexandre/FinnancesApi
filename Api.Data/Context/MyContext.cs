using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<FinancialAccountEntity> FinancialAccounts { get; set; }
        public DbSet<InvestmentEntity> Investments { get; set; } 
        public DbSet<InvestmentTypeEntity> InvestmentTypes { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<CategoryEntity>(new CategoryMap().Configure); 
            modelBuilder.Entity<FinancialAccountEntity>(new FinancialAccountMap().Configure);
            modelBuilder.Entity<InvestmentEntity>(new InvestmentMap().Configure);
            modelBuilder.Entity<InvestmentTypeEntity>(new InvestmentTypeMap().Configure);
          
        }
    }
}
