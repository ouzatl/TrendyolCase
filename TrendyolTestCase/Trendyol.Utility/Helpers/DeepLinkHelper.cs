using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Trendyol.Utility.Constants;

namespace Trendyol.Utility.Helpers
{
    public class DeepLinkHelper
    {
        string deepLinkResult = DeepLinkConstants.HOME_PAGE_DEEPLINK;

        //Could not review the code
        public string UppercaseFirst(string word)
        {
            if (string.IsNullOrEmpty(word))
                return string.Empty;

            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public string LowercaseFirst(string word)
        {
            if (string.IsNullOrEmpty(word))
                return string.Empty;

            return char.ToLower(word[0]) + word.Substring(1);
        }

        public bool IsUrlValid(string url)
        {
            Regex urlValidation = new Regex(RegexConstants.WEB_URL_CHECK_REGEX);

            return urlValidation.IsMatch(url);
        }

        public string GetDeepLinkForProductPage(string webUrl)
        {
            var url = new Uri(webUrl);
            var webUrlParameters = webUrl.Split("-p-");
            var contentId = !string.IsNullOrEmpty(webUrlParameters[1]) ? webUrlParameters[1].Split("?")[0] : string.Empty;
            var optionalParameters = HttpUtility.ParseQueryString(url.Query).ToString();

            if (!string.IsNullOrEmpty(contentId))
            {
                deepLinkResult = string.Format(DeepLinkConstants.CONTENT_ID_DEEPLINK, contentId);

                if (!string.IsNullOrEmpty(optionalParameters))
                {
                    foreach (var item in optionalParameters.Split("&"))
                    {
                        deepLinkResult = ($"{deepLinkResult}&{UppercaseFirst(item)}").Replace("BoutiqueId", "CampaignId"); ;
                    }
                }
            }

            return deepLinkResult;
        }

        public string GetDeepLinkForSearchPage(string webUrl)
        {
            if (webUrl.Contains("q="))
            {
                var query = webUrl.Split("q=")[1];
                if (!string.IsNullOrEmpty(query))
                    deepLinkResult = string.Format(DeepLinkConstants.SEARCH_QUERY_DEEPLINK, query);
            }

            return deepLinkResult;
        }

        public string GetWebUrlForProductPage(string deepLink)
        {
            var webUrlResult = DeepLinkConstants.HOME_PAGE_WEB;
            var url = new Uri(deepLink);
            const string productBaseUrl = "http://www.trendyol.com/{0}";
            var parsedQuery = HttpUtility.ParseQueryString(url.Query);
            parsedQuery.Remove("Page");
            var urlMappingList = new Dictionary<string, string>() {
                { "CampaignId", "boutiqueId" },
                { "MerchantId", "merchantId" },}; //We can get from DB;


            string controllerName = "brand/name-p-{0}";
            var contentId = parsedQuery.Get("ContentId");
            parsedQuery.Remove("ContentId");
            if (string.IsNullOrEmpty(contentId)) return webUrlResult;
            else
            {
                webUrlResult = string.Format(productBaseUrl, string.Format(controllerName, contentId));
                webUrlResult += parsedQuery.toQueryString();
                urlMappingList.ToList().ForEach(x => webUrlResult = webUrlResult.Replace(x.Key, x.Value));
            }

            return webUrlResult;
        }

        public string GetWebUrlForSearchPage(string deepLink)
        {
            var webUrlResult = DeepLinkConstants.HOME_PAGE_WEB;
            const string searchBaseUrl = "http://www.trendyol.com/{0}";
            var query = deepLink.Split("Query=")[1];
            if (!string.IsNullOrEmpty(query))
                webUrlResult = string.Concat(string.Format(searchBaseUrl, "tum--urunler?q="), query);

            return webUrlResult;
        }
    }
}