namespace Trendyol.Data.Models
{
    public class DeepLink
    {
        public int Id { get; set; }
        public string DeepLinkRequest { get; set; }
        public string WebUrlRequest { get; set; }
        public string WebUrlResponse { get; set; }
        public string DeepLinkResponse { get; set; }
    }
}