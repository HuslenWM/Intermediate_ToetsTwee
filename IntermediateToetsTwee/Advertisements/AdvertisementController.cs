using System.Collections.Generic;

namespace IntermediateToetsTwee.Advertisements
{
    public class AdvertisementController : IAdvertisementController
    {


        public List<IOnlineAdvertisement> GetIOnlineAdvertisements(List<IAdvertisement> advertisements)
        {
            if (advertisements == null || !advertisements.Any())
            {
                throw new Exception("Advertisements is null or empty");
            }
            var onlineAdvertisements = new List<IOnlineAdvertisement>();

            foreach (var advertisement in advertisements)
            {
                if (advertisement is IOnlineAdvertisement)
                {
                    onlineAdvertisements.Add((IOnlineAdvertisement)advertisement);
                }
            }

            return onlineAdvertisements;
        }
        public List<Billboard> GetBillboards(List<IAdvertisement> advertisements)
        {
            if (advertisements == null || !advertisements.Any())
            {
                throw new Exception("Advertisements is null or empty");
            }

            var billboards = new List<Billboard>();
            foreach (var advertisement in advertisements)
            {
                if (advertisement is Billboard)
                {
                    billboards.Add((Billboard)advertisement);
                }
            }
            return billboards;
        }

        public List<Location> GetBillboardsLocations(List<IAdvertisement> advertisements)
        {
            var billboards = GetBillboards(advertisements);
            if (billboards == null)
            {
                throw new Exception("List is null");
            }

            var billboardLocations = new List<Location>();
            foreach (var billboard in billboards)
            {
                billboardLocations.Add(billboard.Location);
            }

            return billboardLocations;
        }

        public List<Guid> GetGuidsFromAdvertisements(List<IAdvertisement> advertisements)
        {
            if (advertisements == null || !advertisements.Any())
            {
                throw new Exception("Advertisements is null or empty");
            }

            var guids = new List<Guid>();

            foreach (var advertisement in advertisements)
            {
                guids.Add(advertisement.Guid);
            }

            return guids;
        }



    }
}