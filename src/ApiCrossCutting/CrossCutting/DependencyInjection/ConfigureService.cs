using Domain.Interface.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        /// <summary>
        /// Uma configuração de injeção de dependencia, também pode ser achado na classe StartUp!
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {

            //método .AddSingleton: ele não muda a instancia.
            //método .AddTransient: sempre cria uma nova instancia.
            //método .AddScoped: usa a mesma instancia(usar em conexão de banco).

            serviceCollection.AddTransient<IAnswerService, AnswerService>();
            serviceCollection.AddTransient<IQuestionsService, QuestionsService>();
            serviceCollection.AddTransient<IChapterService, ChapterService>();
            serviceCollection.AddTransient<IProductsService, ProductsService>();

        }
    }
}
