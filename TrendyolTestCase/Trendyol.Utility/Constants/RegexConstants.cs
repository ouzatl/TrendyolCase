namespace Trendyol.Utility.Helpers
{
    public static class RegexConstants
    {
        public const string WEB_URL_CHECK_REGEX = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";
        public const string CONTENT_ID_REGEX = @"-p-(.*?)(\?|\w+$)";
    }
}