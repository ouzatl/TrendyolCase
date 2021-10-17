using System.Threading.Tasks;

namespace Trendyol.Service.DeepLinkServices
{
    public interface IDeepLinkService
    {
        Task<string> WebUrlToDeepLink(string webUrl);

        Task<string> DeepLinkToWebUrl(string deepLink);
    }
}