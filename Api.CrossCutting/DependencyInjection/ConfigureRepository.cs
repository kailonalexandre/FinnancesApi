using Api.Data.Repository;
using Api.Domain.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            var ServerVersion = new MySqlServerVersion(new Version(9, 3, 0)); // Use your MySQL version here

            serviceCollection.AddDbContext<MyContext>(options =>
            options.UseMySql("Server=localhost;port=3306;Database=dbAPIFinnances;User Id=root;Password=genesysjp;", ServerVersion));
        }
    }
}