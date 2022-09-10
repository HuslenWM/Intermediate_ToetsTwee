using IntermediateToetsTwee.Advertisements;

namespace IntermediateToetsTwee
{
    public interface ICompany
    {
       
        public string CompanyName { get; set; }
        public List<IUser> Users { get; set; }
        public List<IAdvertisement> Advertisements { get; set; }
        public Location Location { get; set; }
        public IUser ContactPerson { get; set; }
        public int GetVAT();
    }
}