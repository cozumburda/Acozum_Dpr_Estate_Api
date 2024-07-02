using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Acozum_Dpr_Estate_Api.Repositories.AppUserRepositories;
using Acozum_Dpr_Estate_Api.Repositories.BottomGridRepositories;
using Acozum_Dpr_Estate_Api.Repositories.CategoryRepository;
using Acozum_Dpr_Estate_Api.Repositories.ContactRepositories;
using Acozum_Dpr_Estate_Api.Repositories.EmployeeRepositories;
using Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using Acozum_Dpr_Estate_Api.Repositories.MessageRepositories;
using Acozum_Dpr_Estate_Api.Repositories.PopularLocationRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ProductImageRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ProductRepository;
using Acozum_Dpr_Estate_Api.Repositories.PropertyAmenityRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ServiceRepository;
using Acozum_Dpr_Estate_Api.Repositories.StatisticsRepositories;
using Acozum_Dpr_Estate_Api.Repositories.SubFeatureRepositories;
using Acozum_Dpr_Estate_Api.Repositories.TestimonialRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ToDoListRepositories;
using Acozum_Dpr_Estate_Api.Repositories.WhoWeAreRepository;

namespace Acozum_Dpr_Estate_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();

        }
    }
}
