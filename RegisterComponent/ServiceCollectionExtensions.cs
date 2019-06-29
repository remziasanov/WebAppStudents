using AppServices.Interfaces;
using AppServices.Services;
using Domain.Data.Repositories;
using Domain.DataContext;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RegisterComponent
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StudentDataContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ICityLocalRepository, CityLocalRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ICityLocalService, CityLocalService>();
            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<IGroupService, GroupService>();
            return services;
        }
    }
}
