namespace IntermediateToetsTwee.Advertisements
{
    public class Advertisement : IAdvertisement
    {
        public Guid Guid { get; set; }
        public Advertisement()
        {
            Guid =  Guid.NewGuid();
        }
    }
}