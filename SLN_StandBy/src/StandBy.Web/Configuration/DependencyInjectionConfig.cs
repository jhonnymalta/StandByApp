using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StandBy.Web.Extensions;
using StandBy.Web.Services;

namespace StandBy.Web.Configuration
{
    public static class DependencyInjectionConfig
    {


        public static void RegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            var appUrl = configuration.GetSection("apiUrl").Value;
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>(config => { config.BaseAddress = new Uri(appUrl);}) ;
            services.AddHttpClient<IProdutosService, ProdutosService>(config => { config.BaseAddress = new Uri(appUrl); });
            services.AddHttpClient<IClientesService, ClientesService>(config => { config.BaseAddress = new Uri(appUrl); });
            services.AddHttpClient<IPedidosService, PedidosService>(config => { config.BaseAddress = new Uri(appUrl); });
            services.AddHttpClient<IPedidosItensService, PedidosItensService>(config => { config.BaseAddress = new Uri(appUrl); });
            


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

        }
    }
}