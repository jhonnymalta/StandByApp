using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StandBy.Web.Services;

namespace StandBy.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            services.AddHttpClient<IProdutosService, ProdutosServices>();
        }
    }
}