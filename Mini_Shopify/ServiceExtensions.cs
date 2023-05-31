using Mini_Shopify.Entities.Repository.IRepository;
using Mini_Shopify.Entities.Repository;

namespace Mini_Shopify
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
