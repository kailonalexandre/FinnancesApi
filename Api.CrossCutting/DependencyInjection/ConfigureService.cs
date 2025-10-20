using Api.Domain.Interfaces.Services.Account;
using Api.Domain.Interfaces.Services.Category;
using Api.Domain.Interfaces.Services.Investiment;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IUserService, UserService>();
            serviceColletion.AddTransient<IFinnancialAccountRepository, FinnancialAccountService>();
            serviceColletion.AddTransient<ICategoryRepository, CategoryService>();
            serviceColletion.AddTransient<IInvestmentRepository, InvestmentService>();
            serviceColletion.AddTransient<ILoginService, LoginService>();
           
        }
    }
}