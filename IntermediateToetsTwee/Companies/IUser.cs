using IntermediateToetsTwee.Advertisements;

namespace IntermediateToetsTwee.Companies
{
    public interface IUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Location Location { get; set; }
        public ICompany Company { get; set; }
    }
}