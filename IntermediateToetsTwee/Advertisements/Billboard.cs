namespace IntermediateToetsTwee.Advertisements
{
    public class Billboard : Advertisement, IPhysicalAdvertisement
    {
        public Billboard(Location location)
            :base()
        {
            Location = location;
        }
        public Location Location { get; set; }
    }
}