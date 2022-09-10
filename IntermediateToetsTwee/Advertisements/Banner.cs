namespace IntermediateToetsTwee.Advertisements
{
    public class Banner : Advertisement, IOnlineAdvertisement
    {
        private const string BannerUri = "http://cdn.wunderminds.com/banner/";
        public Uri GetUri() => new Uri(BannerUri + Guid);
    }
}