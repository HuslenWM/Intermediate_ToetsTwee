namespace IntermediateToetsTwee.Advertisements
{
    public interface IAdvertisementController
    {
        public List<IOnlineAdvertisement> GetIOnlineAdvertisements(List<IAdvertisement> advertisements);
        public List<Billboard> GetBillboards(List<IAdvertisement> advertisements);
        public List<Location> GetBillboardsLocations(List<IAdvertisement> advertisements);

        public List<Guid> GetGuidsFromAdvertisements(List<IAdvertisement> advertisements);

    }
}