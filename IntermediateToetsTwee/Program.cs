using IntermediateToetsTwee.Advertisements;
using IntermediateToetsTwee.Companies;
using System.Data.Common;

namespace IntermediateToetsTwee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var main = new Main();


        }
    }
    public class Main
    {
        public List<IAdvertisement> Advertisements { get; set; }
        public List<ICompany>? Companies { get; set; }

        public Company nlCompany { get; set; }
        public Company beCompany { get; set; }
        public List<IUser> FirstCompanyUsers { get; set; }
        public List<IUser> SecondCompanyUsers { get; set; }
        public List<IUser> AllUsers { get; set; }
        public List<BeCompany> BeCompanies { get; set; }
        public List<NlCompany> NlCompanies { get; set; }
        public IUser ContactPerson { get; set; }

        public Main()
        {
            var controller = new CompanyController();
            var companies = new List<ICompany>()
            {
                new NlCompany("Nl1"),
                new BeCompany("BE1"),
                new BeCompany("Be2"),
                null,
                new BeCompany("Be3"),
                new BeCompany("BE4"),
                new NlCompany("Nl2"),
                new NlCompany("Nl3")
            };

            // Returns [List<NlCompany>, List<BeCompany>]
            var action = controller.SortCompaniesByCountry(companies);
            Console.WriteLine(action);
            tester();
        }

        public void InitializeData()
        {
            var nlCompany = new NlCompany("NL WunderMinds");
            var beCompany = new BeCompany("BE CodeCapital");
            var ahCompany = new NlCompany("NL Albert Heijn");

            var nlCompanyLoc = new Location("Melkweg", 1, "XXXX");
            var beCompanyLoc = new Location("Verweg", 2, "ZZZZ");
            var ahCompanyLoc = new Location("Meerweg", 3, "FFFF");

            nlCompany.ContactPerson = new User("nlContact", "nl@live.com", new Location("NL eenstraat", 2, "ABCD"), nlCompany);
            beCompany.ContactPerson = new User("beContact", "be@live.com", new Location("BE eenstraat", 3, "EEEE"), beCompany);
            ahCompany.ContactPerson = new User("ahContact", "ah@live.com", new Location("NL eenstraat", 4, "ZZZZ"), ahCompany);

            nlCompany.Users = new List<IUser>()
            {
                new User("Henk", "henk@gmail.com", new Location("DStreet", 5, "1234"), nlCompany),
                new User("Peter", "peter@gmail.com", new Location("EStreet", 6, "1223"), nlCompany),
                new User("Arnold", "arnold@gmail.com", new Location("FStreet", 7, "1332"), nlCompany),
                new User("Pieter", "pieter@gmail.com", new Location("DStreet", 5, "1234"), nlCompany),
                new User("Kayn", "Kayn@gmail.com", new Location("EStreet", 6, "1223"), nlCompany)
            };

            beCompany.Users = new List<IUser>()
            {
                new User("Henk", "henk@gmail.com", new Location("DStreet", 5, "1234"), beCompany),
                new User("Peter", "peter@gmail.com", new Location("EStreet", 6, "1223"), beCompany),
                new User("Arnold", "arnold@gmail.com", new Location("FStreet", 7, "1332"), beCompany),
                new User("Pieter", "pieter@gmail.com", new Location("DStreet", 5, "1234"), beCompany),
                new User("Kayn", "Kayn@gmail.com", new Location("EStreet", 6, "1223"), beCompany)
            };

            ahCompany.Users = new List<IUser>()
            {
                new User("Henk", "henk@gmail.com", new Location("DStreet", 5, "1234"), ahCompany),
                new User("Peter", "peter@gmail.com", new Location("EStreet", 6, "1223"), ahCompany),
                new User("Arnold", "arnold@gmail.com", new Location("FStreet", 7, "1332"), ahCompany),
                new User("Pieter", "pieter@gmail.com", new Location("DStreet", 5, "1234"), ahCompany),
                new User("Kayn", "Kayn@gmail.com", new Location("EStreet", 6, "1223"), ahCompany)
            };

            Advertisements = new List<IAdvertisement>()
            {
                new Banner(),
                new Banner(),
                new SocialMediaPost(),
                new SocialMediaPost(),
                new Billboard(new Location("AStreet", 5, "ABCD")),
                new Billboard(new Location("BStreet", 9, "EFGH")),
                new Advertisement(),
                new Advertisement()
            };

            nlCompany.Advertisements = Advertisements;
            beCompany.Advertisements = Advertisements;
            ahCompany.Advertisements = Advertisements;

            Companies = new List<ICompany>() { nlCompany, beCompany, ahCompany };
        }




        public void tester()
        {
            var controller = new UserController();
            var companyA = new NlCompany("companyA");
            var expected = new User("ContactPersonA", "@live.com", new Location("b", 1, "a"), companyA);
            companyA.ContactPerson = expected;
            var users = new List<IUser>()
            {
                new User("reg", "@live.com", new Location("b",1,"a") ,companyA),
                new User("rege", "@live.com", new Location("b",1,"a") ,companyA),
                expected,
                new User("regex", "@live.com", new Location("b",1,"a") ,companyA),
                new User("regfe", "@live.com", new Location("b",1,"a") ,companyA)
            };

            var actual = controller.GetContactPersonsFromUsers(users);
        }











    }
}