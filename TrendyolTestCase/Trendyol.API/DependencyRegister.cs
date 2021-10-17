using Microsoft.Extensions.DependencyInjection;
using Trendyol.Data.Repository.DeepLinkRepository;
using Trendyol.Service.DeepLinkServices;
using Trendyol.Utility.Helpers;
using Trendyol.Utility.Logging;

namespace Trendyol.API
{
    public class DependencyRegister
    {
        private readonly IServiceCollection _services;
        public DependencyRegister(IServiceCollection services)
        {
            _services = services;
        }

        public void Register()
        {
            //Services
            _services.AddScoped<IDeepLinkService, DeepLinkService>();

            //Repositories
            _services.AddScoped<IDeepLinkRepository, DeepLinkRepository>();

            //Others
            _services.AddScoped<DeepLinkHelper>();
            _services.AddScoped<ICompositeLogger, CompositeLogger>();
        }
    }
}