using IntermediateToetsTwee.Advertisements;
using System.Data.Common;

namespace IntermediateToetsTwee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var main = new Main();
            foreach (var company in main.Companies!)
            {
                if (company is NlCompany)
                {
                    Console.WriteLine(company.ToString());
                }
            }

        }
    }
    public class Main
    {
        public List<IAdvertisement> Advertisements { get; set; }
        public List<ICompany>? Companies { get; set; }
        public Company NlCompany { get; set; }
        public Company BeCompany { get; set; }
        public List<IUser> FirstCompanyUsers { get; set; }
        public List<IUser> SecondCompanyUsers { get; set; }
        public IUser ContactPerson { get; set; }
        public Main()
        {

            Advertisements = new List<IAdvertisement>()
            {
                new Banner(),
                new Banner(),
                new SocialMediaPost(),
                new SocialMediaPost(),
                new Billboard(new Location("AStreet", 5, "ABCD")),
                new Billboard(new Location("BStreet", 9, "EFGH"))
            };
            var locationFirstCompany = new Location("Melkweg", 1, "XXXX");
            var locationSecondCompany = new Location("Verweg", 2, "ZZZZ");

            Companies = new List<ICompany>();
            NlCompany = new NlCompany("NL WunderMinds");
            BeCompany = new BeCompany("BE CodeCapital");
            ContactPerson = new User("Mart", "mart@live.com", new Location("Eenstraat", 2, "ABCD"), NlCompany);

            FirstCompanyUsers = new List<IUser>()
            {
                new User("Henk", "henk@gmail.com", new Location("DStreet", 5, "1234"), NlCompany),
                new User("Peter", "peter@gmail.com", new Location("EStreet", 6, "1223"), NlCompany),
                new User("Arnold", "arnold@gmail.com", new Location("FStreet", 7, "1332"), NlCompany),
                ContactPerson
              
            };

            SecondCompanyUsers = new List<IUser>()
            {
                new User("Arjan", "arjan@gmail.com", new Location("GStreet", 8, "1442"), BeCompany),
                ContactPerson,
                new User("Melissa", "melissa@gmail.com", new Location("HStreet", 9, "1554"), BeCompany),
                new User("Anne", "anne@gmail.com", new Location("IStreet", 10, "2222"), BeCompany)
                
            };

            NlCompany.Users = FirstCompanyUsers;
            NlCompany.Advertisements = Advertisements;
            NlCompany.ContactPerson = ContactPerson;
            NlCompany.Location = locationFirstCompany;

            BeCompany.Users = SecondCompanyUsers;
            BeCompany.Advertisements = Advertisements;
            BeCompany.ContactPerson = ContactPerson;
            BeCompany.Location = locationSecondCompany;
            Companies.Add(NlCompany);
            Companies.Add(BeCompany);

            IsUserCompanyContactPerson();
        }

        public List<IOnlineAdvertisement> GetIOnlineAdvertisements()
        {
            if (Advertisements == null || !Advertisements.Any())
            {
                throw new Exception("Advertisements is null or empty");
            }
            var onlineAdvertisements = new List<IOnlineAdvertisement>();
            foreach (var advertisement in Advertisements)
            {
                if (advertisement is IOnlineAdvertisement)
                {
                    onlineAdvertisements.Add((IOnlineAdvertisement)advertisement);
                }
            }
            return onlineAdvertisements;
        }

        public List<Location> GetBillboardLocations()
        {
            var billboards = GetBillboardsFromAdvertisements();
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

        public List<Billboard> GetBillboardsFromAdvertisements()
        {
            if (Advertisements == null || !Advertisements.Any())
            {
                throw new Exception("Advertisements is null or empty");
            }
            var billboard = new List<Billboard>();

            foreach (var advertisement in Advertisements)
            {
                if (advertisement is Billboard)
                {
                    billboard.Add((Billboard) advertisement);
                }
            }
            return billboard;

        }

        public List<Guid> GetGuidsFromAdvertisements()
        {
            if (Advertisements == null || !Advertisements.Any())
            {
                throw new Exception("Advertisements is null or empty");
            }

            var guids = new List<Guid>();

            foreach (var advertisement in Advertisements)
            {
                guids.Add(advertisement.Guid);
            }

            return guids;
        }

        public List<string> GetCompanyFromUsers()
        {
            if (Companies == null || !Companies.Any())
            {
                throw new Exception("Companies is null or empty");
            }

            var companyUsers = new List<string>();

            foreach (var company in Companies)
            {
                if(company.Users == null || !company.Users.Any())
                {
                    throw new Exception("Users is null or empty");
                }
                foreach (var user in company.Users)
                {
                    companyUsers.Add($"{user.UserName} works at {user.Company.ToString}");
                }
            }
            return companyUsers;
            // Check companies if contains anything
            // Check companies.Users if contains anything
            // Check expected List<string>
        }

        public List<bool> IsUserCompanyContactPerson()
        {
            if (FirstCompanyUsers == null || !FirstCompanyUsers.Any())
            {
                throw new Exception("List of company users is null or empty");
            }

            var boolUserIsContactPerson = new List<bool>();

            Func<User, bool> boolUsers = user => user.Equals(ContactPerson) ? true : false;

            foreach (var user in FirstCompanyUsers)
            {
                boolUserIsContactPerson.Add(boolUsers(user as User));
            }
            return boolUserIsContactPerson;
        }







    }
}