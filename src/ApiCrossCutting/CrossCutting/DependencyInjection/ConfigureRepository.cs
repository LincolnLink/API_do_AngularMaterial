using Data.Context;
using Data.Repository;
using Domain.Interface.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {

            //método .AddSingleton: ele não muda a instancia.
            //método .AddTransient: sempre cria uma nova instancia.
            //método .AddScoped: usa a mesma instancia.
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            

           serviceCollection.AddDbContext<MyContext>(options => 
           options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MinhaAPICore;Trusted_Connection=True;MultipleActiveResultSets=true"));

        }
    }
}
