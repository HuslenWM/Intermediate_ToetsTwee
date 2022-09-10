using Xunit;
using IntermediateToetsTwee;
using Xunit.Sdk;
using IntermediateToetsTwee.Advertisements;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace IntermediateToetsTwee.UnitTesting
{
    public class UnitTestsMain
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetIOnlineAdvertisements_ListEmptyOrNull_ThrowsException(bool needsNull)
        {
            var main = new Main();
            main.Advertisements = needsNull ? null : new List<IAdvertisement>();
            //var expected = main.Advertisements.Where(ad => ad is IOnlineAdvertisement).ToList();
            Assert.Throws<Exception>(() => main.GetIOnlineAdvertisements());
        }
        public void GetIOnlineAdvertisements_valid_()
        {
            var main = new Main();
            main.Advertisements = new List<IAdvertisement>()
            {
                new SocialMediaPost(),
                new SocialMediaPost(),
                new Banner(),
                new Billboard(new Location("astreet",0,"1234")),
                new Advertisement()
            };
            var expected = main.Advertisements.Where(ad => ad is IOnlineAdvertisement);

        }

        [Fact]
        public void GetBillboardsLocations_Valid_List()
        {
            var main = new Main();
            var billboard = new Billboard(new Location("Street", 5, "1123"));
            main.Advertisements = new List<IAdvertisement>()
            {
                new Banner(),
                new SocialMediaPost(),
                new Advertisement(),
                billboard             
            };
            var expected = new List<Location>() {billboard.Location };

            var actual = main.GetBillboardLocations();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetBillboardsFromAdvertisements_ListIsNullOrEmpty_ThrowsException(bool needsNull)
        {
            var main = new Main();
            main.Advertisements = needsNull ? null : new List<IAdvertisement>();

            Assert.Throws<Exception>(() => main.GetBillboardsFromAdvertisements());
        }

        [Fact]
        public void GetBillboardsFromAdvertisements_Valid()
        {
            var main = new Main();
            var billboard = new Billboard(new Location("street", 2, "1234"));
            main.Advertisements = new List<IAdvertisement>()
            {
                new Banner(),
                new SocialMediaPost(),
                new Advertisement(),
                billboard
            };
            var expectedAmount = main.Advertisements.Where(ad => ad is Billboard).Count();

            var actualAmount = main.GetBillboardsFromAdvertisements().Count();

            Assert.Equal(expectedAmount, actualAmount);
        }



        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetGuidsFromAdvertisements_ListIsNullOrEmpty_ThrowsException(bool needsNull)
        {
            // Arrange
            var main = new Main();
            main.Advertisements = needsNull ? null : new List<IAdvertisement>();

            // Assert & act
            Assert.Throws<Exception>(() => main.GetGuidsFromAdvertisements());
        }

        [Fact]
        public void GetGuidsFromAdvertisements_Valid()
        {
            // Arrange
            var main = new Main();
            var expected = main.Advertisements.Count();
            
            //Act
            var actual = main.GetGuidsFromAdvertisements().Count();

            Assert.Equal(expected, actual);

        }


        // Get Company From Users

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetCompanyFromUsers_CompaniesEmptyOrNull_ThrowException(bool needsNull)
        {
            // Arrange
            var main = new Main();
            main.Companies = needsNull ? null : new List<ICompany>() { };

            // Assert
            Assert.Throws<Exception>(() => main.GetCompanyFromUsers());
        }

        [Fact]
        public void GetCompanyFromUsers_FilledCompanyUsers_ListOfStrings()
        {
            // Arrange
            var main = new Main();
            var expect = main.FirstCompanyUsers.Count + main.SecondCompanyUsers.Count;

            // Act
            var result = main.GetCompanyFromUsers().Count();
            
            Assert.Equal(expect, result);
        }

        // Is User Company Contact Person

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsUserCompanyContactPerson_UserListEmptyOrNull_ThrowsException(bool needsNull)
        {
            var main = new Main();
            main.FirstCompanyUsers = needsNull? null : new List<IUser>(){ };

            Assert.Throws<Exception>(() => main.IsUserCompanyContactPerson());
        }

        [Fact]
        public void IsUserCompanyContactPerson_FilledUsers_ListOfBool()
        {
            var main = new Main();
            var expect = main.FirstCompanyUsers.Count;

            var result = main.IsUserCompanyContactPerson().Count();

            Assert.Equal(expect, result);
        }

        // Calculate company tax

        [Theory]
        [InlineData(220.0)]
        [InlineData(123.5)]
        [InlineData(39.9)]
        public void CalculateCompanyTaxNL_Valid(double value)
        {
            var main = new Main();
            var companyNl = new NlCompany("Nederland");
            var expectedNl = value + (value / 100 * main.NlCompany.GetVAT());

            var actualNl = main.NlCompany.CalculateCompanyTax(50.0, main.NlCompany);


            Assert.Equal(expectedNl, actualNl);
        }

        [Theory]
        [InlineData(50.0)]
        [InlineData(67.0)]
        [InlineData(39.5)]
        public void CalculateCompanyTaxBe_Valid(double value)
        {
            var main = new Main();
            var companyBe = new BeCompany("Belgie");
            var expectedBe = value + (value / 100 * main.BeCompany.GetVAT());

            var actualBe = companyBe.CalculateCompanyTax(value, companyBe);

            Assert.Equal(expectedBe, actualBe);
        }

        [Fact]
        public void CalculateCompanyTaxNl_CompanyIsNull_ThrowsException()
        {
            var main = new Main();
            var companyNl = new NlCompany("Nederland");

            Assert.Throws<Exception>(() => companyNl.CalculateCompanyTax(40.0, null) );
        }


    }

}