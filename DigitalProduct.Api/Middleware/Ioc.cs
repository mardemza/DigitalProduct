using DigitalProduct.Application.Clients;
using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Notifications;
using DigitalProduct.Application.Products;
using DigitalProduct.Application.Shoppings;

namespace DigitalProduct.Api.Middleware
{
    public static class Ioc
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IClient, Client>();
            services.AddScoped<IShoppingMediator, ShoppingMediator>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IShoppingService, ShoppingService>();

            return services;
        }
    }
}
