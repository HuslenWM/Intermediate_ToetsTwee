using IntermediateToetsTwee.Advertisements;
using IntermediateToetsTwee.Companies;
using System.Collections.Generic;
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

        public List<IUser> AllUsers { get; set; }
        public List<BeCompany> BeCompanies { get; set; }
        public List<NlCompany> NlCompanies { get; set; }
        public List<IUser> ContactPersons { get; set; }
        public ICompanyController CompanyController { get; set; }
        public IAdvertisementController AdvertisementController { get; set; }
        public IUserController UserController { get; set; }

        public Main()
        {
            
            InitializeData();
            
            performFunctions(new AdvertisementController(), new CompanyController(), new UserController());
   /*         var companies = new List<ICompany>()
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
*/
        }

        public void InitializeData()
        {
            AllUsers = new List<IUser>();

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
                nlCompany.ContactPerson,
                new User("Pieter", "pieter@gmail.com", new Location("DStreet", 5, "1234"), nlCompany),
                new User("Kayn", "Kayn@gmail.com", new Location("EStreet", 6, "1223"), nlCompany)
            };

            beCompany.Users = new List<IUser>()
            {
                new User("Henk", "henk@gmail.com", new Location("DStreet", 5, "1234"), beCompany),
                new User("Peter", "peter@gmail.com", new Location("EStreet", 6, "1223"), beCompany),
                new User("Arnold", "arnold@gmail.com", new Location("FStreet", 7, "1332"), beCompany),
                new User("Pieter", "pieter@gmail.com", new Location("DStreet", 5, "1234"), beCompany),
                beCompany.ContactPerson,
                new User("Kayn", "Kayn@gmail.com", new Location("EStreet", 6, "1223"), beCompany)
            };

            ahCompany.Users = new List<IUser>()
            {
                new User("Henk", "henk@gmail.com", new Location("DStreet", 5, "1234"), ahCompany),
                new User("Peter", "peter@gmail.com", new Location("EStreet", 6, "1223"), ahCompany),
                ahCompany.ContactPerson,
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
            AllUsers.AddRange(nlCompany.Users);
            AllUsers.AddRange(beCompany.Users);
            AllUsers.AddRange(ahCompany.Users);
        }

        public void performFunctions(IAdvertisementController advertisementController, 
                                    ICompanyController companyController, 
                                    IUserController userController)
        {
            AdvertisementController = advertisementController;
            CompanyController = companyController;
            UserController = userController;

            var onlineAdvertisements = AdvertisementController.GetIOnlineAdvertisements(Advertisements);
            Console.WriteLine($"Results from GetOnlineAdvertisements\n");
            foreach (var onlineAdvertisement in onlineAdvertisements) { Console.WriteLine($"{onlineAdvertisement.ToString()}"); }
            
            var billboards = AdvertisementController.GetBillboards(Advertisements);
            Console.WriteLine($"\nResults from GetBillBoards\n");
            foreach (var billboard in billboards) { Console.WriteLine($"{billboard}"); }
            
            var guids = AdvertisementController.GetGuidsFromAdvertisements(Advertisements);
            Console.WriteLine("\nResults from GetGuids\n");
            foreach (var guid in guids) { Console.WriteLine($"{guid.ToString()}"); }
            
            var companiesSorted = CompanyController.SortCompaniesByCountry(Companies);
            var nlCompanies = (List<NlCompany>)companiesSorted[0];
            var beCompanies = (List<BeCompany>)companiesSorted[1];
            Console.WriteLine("\nResults from SortCompanies\n");
            foreach (var beCompany in beCompanies) { Console.WriteLine(beCompany.CompanyName); }
            foreach (var nlCompany in nlCompanies) { Console.WriteLine(nlCompany.CompanyName); }

            var contactPersons = UserController.GetContactPersonsFromUsers(AllUsers);
            Console.WriteLine("\nResults from getContactPersons\n");
            foreach (var user in contactPersons) { Console.WriteLine(user.UserName); }

        }
















    }
}