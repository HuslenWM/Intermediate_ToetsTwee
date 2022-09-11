namespace IntermediateToetsTwee.Advertisements
{
    public class SocialMediaPost : Advertisement, IOnlineAdvertisement
    {
        private const string SocialUri = "http://cdn.wunderminds.com/social/";
        public Uri GetUri() => new Uri(SocialUri + Guid);
        public override string ToString() => $"IOnlineAdvertisement {SocialUri}";
    }
}