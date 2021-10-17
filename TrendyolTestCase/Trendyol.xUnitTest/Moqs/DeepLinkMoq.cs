using Moq;
using Trendyol.Data.Repository.DeepLinkRepository;
using Trendyol.Service.DeepLinkServices;
using Trendyol.Utility.Helpers;
using Trendyol.Utility.Logging;

namespace Trendyol.xUnitTest.Moqs
{
    public static class DeepLinkMoq
    {
        //WEBURL
        public const string WEB_URL_HOME_PAGE = "http://www.trendyol.com";
        public const string WEB_URL_WRONG_HOME_PAGE = "htttp://www.trendyol.om/";
        public const string WEB_URL_WITH_P_TAG_CONTENTID_BOUTIQUEID_MERCHANTID = "http://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064";
        public const string WEB_URL_WITH_P_TAG_CONTENTID = "http://www.trendyol.com/casio/erkek-kol-saati-p-1925865";
        public const string WEB_URL_WITH_P_TAG = "http://www.trendyol.com/casio/erkek-kol-saati-p-";
        public const string WEB_URL_WITH_P_TAG_CONTENTID_BOUTIQUEID = "http://www.trendyol.com/casio/erkek-kol-saati-p-1925865?boutiqueId=439892";
        public const string WEB_URL_WITH_P_TAG_CONTENTID_MERCHANTID = "http://www.trendyol.com/casio/erkek-kol-saati-p-1925865?merchantId=105064";
        public const string WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER = "http://www.trendyol.com/tum--urunler?q=elbise";
        public const string WEB_URL_WITH_TUM_URUNLER_TAG = "http://www.trendyol.com/tum--urunler";
        public const string WEB_URL_WITH_TUM_URUNLER_TAG_WITH_Q_PARAMETER_HASH = "http://www.trendyol.com/tum--urunler?q=%C3%BCt%C3%BC";
        public const string WEB_URL_WITH_HESABIM_FAVORILER = "http://www.trendyol.com/Hesabim/Favoriler";
        public const string WEB_URL_WITH_HESABIM_CHAPTER_FAVORILER = "http://www.trendyol.com/Hesabim/#/Favoriler";
        public const string WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID_BOUTIQUEID_MERCHANTID = "http://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892&merchantId=105064";
        public const string WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID = "http://www.trendyol.com/brand/name-p-1925865";
        public const string WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID_BOUTIQUEID = "http://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892";
        public const string WEB_URL_WITH_BRAND_NAME_P_TAG_CONTENTID_MERCHANTID = "http://www.trendyol.com/brand/name-p-1925865?merchantId=105064";

        //DEEPLINK
        public const string DEEP_LINK_HOME_PAGE = "ty://?Page=Home";
        public const string DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID_MERCHANTID = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064";
        public const string DEEP_LINK_PRODUCT_WITH_CONTENTID = "ty://?Page=Product&ContentId=1925865";
        public const string DEEP_LINK_PRODUCT = "ty://?Page=Product";
        public const string DEEP_LINK_PRODUCT_WITH_CONTENTID_CAMPIGNID = "ty://?Page=Product&ContentId=1925865&CampaignId=439892";
        public const string DEEP_LINK_PRODUCT_WITH_CONTENTID_MERCHANTID = "ty://?Page=Product&ContentId=1925865&MerchantId=105064";
        public const string DEEP_LINK_SEARCH_WITH_QUERY = "ty://?Page=Search&Query=elbise";
        public const string DEEP_LINK_SEARCH_WITH_HASH_QUERY = "ty://?Page=Search&Query=%C3%BCt%C3%BC";
        public const string DEEP_LINK_SEARCH = "ty://?Page=Search";
        public const string DEEP_LINK_SEARCH_WITH_FAVORITES = "ty://?Page=Favorites";
        public const string DEEP_LINK_SEARCH_WITH_ORDERS = "ty://?Page=Orders";

        public static ICompositeLogger GetLogger() => Mock.Of<ICompositeLogger>();
        public static IDeepLinkRepository GetDeepLinkRepository() => Mock.Of<IDeepLinkRepository>();
        public static IDeepLinkService GetDeepLinkService() => new DeepLinkService(GetDeepLinkRepository(), GetLogger(), new DeepLinkHelper());
    }
}