

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Concrete;

namespace TeknoMarketim.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepositoryBase<,>));

            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICartRepository, EfCartRepository>();
            services.AddScoped<IWishListRepository, EfWishListRepository>();
            services.AddScoped<ICampaignRepository, EfCampaignRepository>();
            services.AddScoped<IContactRepository, EfContactRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<IOrderItemRepository, EfOrderItemRepository>();
            services.AddScoped<ICustomerAddressRepository, EfCustomerAddressRepository>();
            services.AddScoped<ICustomerCardRepository, EfCustomerCardRepository>();
            services.AddScoped<ICartRepository, EfCartRepository>();

            return services;

        }
    }
}
