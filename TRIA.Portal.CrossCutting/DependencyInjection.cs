using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRIA.Portal.Data.Repository;
using TRIA.Portal.Domain.Interfaces.Repository;
using TRIA.Portal.Domain.Interfaces.Services;
using TRIA.Portal.Service.Service;

namespace TRIA.Portal.CrossCutting
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            ////Service
           services.AddScoped<ITokenService, TokenService>();
           services.AddScoped<IUserService, UserService>();
           services.AddScoped<IProdutoServicoService, ProdutoServicoService>();
           services.AddScoped<IClienteContatoService, ClienteContatoService>();

            ////Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteContatoRepository, ClienteContatoRepository>();
            services.AddScoped<IProdutoServicoRepository, ProdutoServicoRepository>();
            
        }
    }
}
