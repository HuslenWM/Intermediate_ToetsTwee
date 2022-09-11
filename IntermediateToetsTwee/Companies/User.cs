using IntermediateToetsTwee.Advertisements;

namespace IntermediateToetsTwee.Companies
{
    public class User : IUser
    {
        public User(string userName, string email, Location location, Company company)
        {
            UserName = userName;
            Email = email;
            Location = location;
            Company = company;
        }


        public string UserName { get; set; }
        public string Email { get; set; }
        public Location Location { get; set; }
        public ICompany Company { get; set; }
    }
}