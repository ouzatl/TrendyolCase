using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Trendyol.Data.Models;
using Trendyol.Data.Repository.DeepLinkRepository;
using Trendyol.Utility.Constants;
using Trendyol.Utility.Helpers;
using Trendyol.Utility.Logging;

namespace Trendyol.Service.DeepLinkServices
{
    public class DeepLinkService : IDeepLinkService
    {
        private readonly DeepLinkHelper _deepLinkHelper;
        private readonly IDeepLinkRepository _deepLinkRepository;
        private readonly ICompositeLogger _logger;
        public DeepLinkService(IDeepLinkRepository deepLinkRepository, ICompositeLogger logger, DeepLinkHelper deepLinkHelper)
        {
            _deepLinkRepository = deepLinkRepository;
            _logger = logger;
            _deepLinkHelper = deepLinkHelper;
        }

        public async Task<string> WebUrlToDeepLink(string webUrl)
        {
            var deepLinkResult = DeepLinkConstants.HOME_PAGE_DEEPLINK;
            try
            {   //if-else can be generic service here  
                if (_deepLinkHelper.IsUrlValid(webUrl))
                {
                    if (webUrl.Contains(DeepLinkConstants.PRODUCT_PAGE_WEB_URL_KEY))
                    {
                        deepLinkResult = _deepLinkHelper.GetDeepLinkForProductPage(webUrl);
                    }
                    else if (webUrl.Contains(DeepLinkConstants.SEARCH_WEB_URL_KEY))
                    {
                        deepLinkResult = _deepLinkHelper.GetDeepLinkForSearchPage(webUrl);
                    }
                }

                await _deepLinkRepository.Add(new DeepLink { WebUrlRequest = webUrl, DeepLinkResponse = deepLinkResult });

            }
            catch (System.Exception ex)
            {
                deepLinkResult = DeepLinkConstants.HOME_PAGE_DEEPLINK;
                _logger.Error("WebUrlToDeepLink Error :", ex);
            }

            return deepLinkResult;
        }

        public async Task<string> DeepLinkToWebUrl(string deepLink)
        {
            var webUrlResult = DeepLinkConstants.HOME_PAGE_WEB;
            //check deeplink is valid
            if (string.IsNullOrEmpty(deepLink)) return webUrlResult;

            var url = new Uri(deepLink);
            var parsedQuery = HttpUtility.ParseQueryString(url.Query);
            var queryType = parsedQuery.Get("Page");
            try
            {   //if-else can be generic service here 
                if (queryType.Equals("Product"))
                {
                    webUrlResult = _deepLinkHelper.GetWebUrlForProductPage(deepLink);
                }
                else if(queryType.Equals("Search"))
                {
                    webUrlResult = _deepLinkHelper.GetWebUrlForSearchPage(deepLink);
                }

                await _deepLinkRepository.Add(new DeepLink { DeepLinkRequest = deepLink, WebUrlResponse = webUrlResult });
            }
            catch (System.Exception ex)
            {
                _logger.Error("DeepLinkToWebUrl Error :", ex);
            }

            return webUrlResult;
        }
    }
}