using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
  public static class ServiceRegistration
  {
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

      services.AddTransient<IWordTypeRepositoryAsync, WordTypeRepositoryAsync>();
      services.AddTransient<IWordLibraryRepositoryAsync, WordLibraryRepositoryAsync>();
      services.AddTransient<IConstructedSentenceRepositoryAsync, ConstructedSentenceRepositoryAsync>();
    }
  }
}
