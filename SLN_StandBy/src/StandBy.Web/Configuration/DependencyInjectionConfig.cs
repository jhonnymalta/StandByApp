using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StandBy.Web.Extensions;
using StandBy.Web.Services;

namespace StandBy.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            services.AddHttpClient<IProdutosService, ProdutosService>();
            services.AddHttpClient<IClientesService, ClientesService>();
            services.AddHttpClient<IPedidosService, PedidosService>();
            services.AddHttpClient<IPedidosItensService, PedidosItensService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

        }
    }
}