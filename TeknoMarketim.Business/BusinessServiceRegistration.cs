

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Business.Concrete;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Concrete;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            
            // services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepositoryBase<,>));


            var entityAssembly = typeof(Product).Assembly;
            var entityTypes = entityAssembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract
                                                                            && t.Namespace != null
                                                                            &&(t.Namespace.Contains("Entities") || t.Namespace.Contains("Entities")));                                          

            foreach (var entityType in entityTypes)
            {
                var repositoryInterface = typeof(IGenericRepository<>).MakeGenericType(entityType);
                var repositoryImplementation = typeof(EfGenericRepositoryBase<,>)
                    .MakeGenericType(entityType, typeof(AppDbContext));
                services.AddScoped(repositoryInterface, repositoryImplementation);
            }
            Console.WriteLine($"{entityTypes.Count()} Generic Register");


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

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IOrderItemService, OrderItemManager>();
            services.AddScoped<ICampaignService, CampaignManager>();
            services.AddScoped<ICustomerAddressService, CustomerAddressManager>();
            services.AddScoped<ICustomerCardService, CustomerCardManager>();
            services.AddScoped<IWishListService, WishListManager>();

            return services;

        }
    }
}
