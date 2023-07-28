using HotelDAL;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBL
{
    public static class IServiceCollectionExtensions
    {
        public static void AddBLServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddScoped<IScheduleService, ScheduleService>();
            serviceCollection.AddScoped<IQRCodeService, QRCodeService>();
            serviceCollection.AddScoped<IChatService, ChatService>();
            serviceCollection.AddRepositories();
        }
    }
}