using System.Threading.Tasks;
using Trendyol.Service.DeepLinkServices;
using Trendyol.Utility.Helpers;
using Trendyol.xUnitTest.Moqs;
using Xunit;

namespace Trendyol.xUnitTest.DeepLink
{
    public class DeepLinkTest
    {
        [Fact]
        public async Task WebUrlToDeepLink_EMPTY_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink("");

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_HOME_PAGE);
        }

        [Fact]
        public async Task WebUrlToDeepLink_NULL_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(null);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_HOME_PAGE);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_P_TAG_CONTENTID_BOUTIQID_MERCHANTID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID_BOUTIQUEID_MERCHANTID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID_MERCHANTID);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_P_TAG_CONTENTID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_P_TAG()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_P_TAG);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_HOME_PAGE);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_P_TAG_CONTENTID_BOUTIQID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID_BOUTIQUEID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_P_TAG_CONTENTID_MERCHANTID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID_MERCHANTID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_MERCHANTID);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_TUM_URUNLER_TAG_Q_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_SEARCH_WITH_QUERY);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_TUM_URUNLER_TAG_Q_PARAMETER_HASH_VALUE()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER_HASH);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_SEARCH_WITH_HASH_QUERY);
        }

        [Fact]
        public async Task WebUrlToDeepLink_WEB_URL_HAS_TUM_URUNLER_TAG()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().WebUrlToDeepLink(DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_HOME_PAGE);
        }

        [Fact]
        public async Task IsUrlValid_True_Url()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.IsUrlValid(DeepLinkMoq.WEB_URL_HOME_PAGE);

            Assert.True(result);
        }

        [Fact]
        public async Task IsUrlValid_False_Url()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.IsUrlValid(DeepLinkMoq.WEB_URL_WRONG_HOME_PAGE);

            Assert.False(result);
        }

        [Fact]
        public async Task UppercaseFirst_word_Word()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.UppercaseFirst("word");

            Assert.Equal(result, "Word");
        }

        [Fact]
        public async Task LowercaseFirst_Word_word()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.LowercaseFirst("Word");

            Assert.Equal(result, "word");
        }

        [Fact]
        public async Task GetDeepLinkForProductPage_WEB_URL_HAS_P_TAG_CONTENTID_BOUTIQID_MERCHANTID()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForProductPage(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID_BOUTIQUEID_MERCHANTID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID_MERCHANTID);
        }

        [Fact]
        public async Task GetDeepLinkForProductPage_WEB_URL_HAS_P_TAG_CONTENTID()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForProductPage(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID);
        }

        [Fact]
        public async Task GetDeepLinkForProductPage_WEB_URL_HAS_P_TAG()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForProductPage(DeepLinkMoq.WEB_URL_WITH_P_TAG);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_HOME_PAGE);
        }

        [Fact]
        public async Task GetDeepLinkForProductPage_WEB_URL_HAS_P_TAG_CONTENTID_BOUTIQID()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForProductPage(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID_BOUTIQUEID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID);
        }

        [Fact]
        public async Task GetDeepLinkForProductPage_WEB_URL_HAS_P_TAG_CONTENTID_MERCHANTID()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForProductPage(DeepLinkMoq.WEB_URL_WITH_P_TAG_CONTENTID_MERCHANTID);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_MERCHANTID);
        }

        [Fact]
        public async Task GetDeepLinkForSearchPage_WEB_URL_HAS_TUM_URUNLER_TAG_Q_PARAMETER()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForSearchPage(DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_SEARCH_WITH_QUERY);
        }

        [Fact]
        public async Task GetDeepLinkForSearchPage_WEB_URL_HAS_TUM_URUNLER_TAG_Q_PARAMETER_HASH_VALUE()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForSearchPage(DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER_HASH);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_SEARCH_WITH_HASH_QUERY);
        }

        [Fact]
        public async Task GetDeepLinkForSearchPage_WEB_URL_HAS_TUM_URUNLER_TAG()
        {
            DeepLinkHelper webUrl = new DeepLinkHelper();
            var result = webUrl.GetDeepLinkForSearchPage(DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG);

            Assert.Equal(result, DeepLinkMoq.DEEP_LINK_HOME_PAGE);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_EMPTY_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl("");

            Assert.Equal(result, DeepLinkMoq.WEB_URL_HOME_PAGE);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_NULL_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(null);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_HOME_PAGE);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_PRODUCT_TAG_CONTENTID_CAMPAIGNID_MERCHANTID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID_MERCHANTID);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID_BOUTIQUEID_MERCHANTID);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_PRODUCT_TAG_CONTENTID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_PRODUCT_TAG()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_PRODUCT);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_HOME_PAGE);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_PRODUCT_TAG_CONTENTID_CAMPAIGNID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID_BOUTIQUEID);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_PRODUCT_TAG_CONTENTID_MERCHANTID()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_PRODUCT_WITH_CONTENTID_MERCHANTID);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID_MERCHANTID);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_SEARCH_TAG_QUERY_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_SEARCH_WITH_QUERY);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_SEARCH_TAG_HASH_QUERY_PARAMETER()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_SEARCH_WITH_HASH_QUERY);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER_HASH);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_SEARCH_TAG()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_SEARCH);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_HOME_PAGE);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_FAVORITES()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_SEARCH_WITH_FAVORITES);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_HOME_PAGE);
        }

        [Fact]
        public async Task DeepLinkToWebUrl_DEEPLINK_ORDERS()
        {
            var result = await DeepLinkMoq.GetDeepLinkService().DeepLinkToWebUrl(DeepLinkMoq.DEEP_LINK_SEARCH_WITH_ORDERS);

            Assert.Equal(result, DeepLinkMoq.WEB_URL_HOME_PAGE);
        }
    }
}