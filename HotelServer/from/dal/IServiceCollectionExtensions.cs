using HotelDAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HotelDAL
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddDbContext<HotelContext>();
        }
    }
}