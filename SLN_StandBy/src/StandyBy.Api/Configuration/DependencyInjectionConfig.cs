using StandBy.Business.Intefaces;
using StandBy.Business.Notificacoes;
using StandBy.Business.Services;
using StandyBy.Data.Context;
using StandyBy.Data.Repository;

namespace StandyBy.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<StandByDBContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoServices, ProdutoService>();
            services.AddScoped<IClienteServices, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoServices, PedidoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoItemServices, PedidoItemService>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();


            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
