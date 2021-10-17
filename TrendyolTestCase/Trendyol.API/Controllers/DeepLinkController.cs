using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trendyol.Service.DeepLinkServices;

namespace Trendyol.API.Controllers
{
    public class DeepLinkController : Controller
    {
        private readonly IDeepLinkService _deepLinkService;
        public DeepLinkController(IDeepLinkService deepLinkService)
        {
            _deepLinkService = deepLinkService;
        }

        [HttpGet("DeepLink")]
        public async Task<IActionResult> DeepLink(string webUrl)
        {
            var result = await _deepLinkService.WebUrlToDeepLink(webUrl);

            return Ok(result);
        }

        [HttpGet("WebUrl")]
        public async Task<IActionResult> WebUrl(string deepLink)
        {
            var result = await _deepLinkService.DeepLinkToWebUrl(deepLink);

            return Ok(result);
        }
    }
}