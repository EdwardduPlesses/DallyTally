using DallyTally.Application.Common.Interfaces;
using DallyTally.Domain.Common.Interfaces;
using DallyTally.Domain.Repositories;
using DallyTally.Infrastructure.Persistence;
using DallyTally.Infrastructure.Repositories;
using DallyTally.Infrastructure.Services;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace DallyTally.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IEntryTypeRepository, EntryTypeRepository>();
            services.AddTransient<ITimeEntryRepository, TimeEntryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            return services;
        }
    }
}