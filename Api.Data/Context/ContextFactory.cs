using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado Para criar migrations
            var connectionString = "Server=localhost;port=3306;Database=dbAPIFinnances;User Id=root;Password=genesysjp;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var ServerVersion = new MySqlServerVersion(new Version(9, 3, 0)); // Use your MySQL version here
            optionsBuilder.UseMySql(connectionString, ServerVersion);
            return new MyContext(optionsBuilder.Options);
        }
    }

}
