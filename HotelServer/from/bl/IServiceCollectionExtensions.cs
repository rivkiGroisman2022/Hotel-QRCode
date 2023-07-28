using HotelDAL;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBL
{
    public static class IServiceCollectionExtensions
    {
        public static void AddBLServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IQRCode, QRCodeService>();
            //serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddRepositories();
        }
    }
}