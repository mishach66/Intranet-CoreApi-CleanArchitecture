using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<ISexRepository, SexRepository>();
            services.AddTransient<IVacancyRepository, VacancyRepository>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
