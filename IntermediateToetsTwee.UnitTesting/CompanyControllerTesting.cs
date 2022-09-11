
using IntermediateToetsTwee.Companies;

namespace IntermediateToetsTwee.UnitTesting
{
    public class CompanyControllerTesting
    {

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SortCompaniesByCountry_CompaniesNullOrEmpty_ThrowsException(bool needsNull)
        {
            var controller = new CompanyController();
            var companies = needsNull ? null : new List<ICompany>();

            var caughtException = Assert.Throws<Exception>(() => controller.SortCompaniesByCountry(companies));

            Assert.Equal("Companies is null or empty", caughtException.Message);
        }

        [Fact]
        public void SortCompaniesByCountry_Valid_ArrayOfCompanies()
        {
            var controller = new CompanyController();
            var expectedNLCompanies = new List<NlCompany>() { new NlCompany("Nl1"),new NlCompany("Nl2"),new NlCompany("Nl3") };
            var expectedBECompanies = new List<BeCompany>() { new BeCompany("BE1"), new BeCompany("Be2"), new BeCompany("Be3"), new BeCompany("BE4") };

            var companies2 = new List<ICompany>();
            companies2.Add(null);
            companies2.AddRange(expectedNLCompanies);
            companies2.AddRange(expectedBECompanies);


            // Returns [List<NlCompany>, List<BeCompany>]
            var action = controller.SortCompaniesByCountry(companies2);
            var actualNlCompanies = action[0];
            var actualBeCompanies = action[1];

            Assert.Equal(expectedNLCompanies, actualNlCompanies);
            Assert.Equal(expectedBECompanies, actualBeCompanies);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetNlCompanies_CompaniesNullOrEmpty_ThrowsException(bool needsNull)
        {
            var controller = new CompanyController();
            var companies = needsNull ? null : new List<ICompany>();

            var caughtException = Assert.Throws<Exception>(() => controller.GetNlCompanies(companies));
            Assert.Equal("Companies is null or empty", caughtException.Message);
        }

        [Fact]
        public void GetNlCompanies_Valid_ListNlCompanies()
        {
            var controller = new CompanyController();
            var nlCompany = new NlCompany("Nl1");
            var nl2Company = new NlCompany("NL2");

            var expected = new List<NlCompany>() { nlCompany, nl2Company };
            var companies = new List<ICompany>()
            {
                nlCompany,
                new BeCompany("BE1"),
                new BeCompany("Be2"),
                null,
                new BeCompany("Be3"),
                new BeCompany("BE4"),
                nl2Company   
            };

            var nlCompanies = controller.GetNlCompanies(companies);

            Assert.NotNull(nlCompanies);
            Assert.Equal(expected,nlCompanies);

        }

        [Fact]
        public void GetNlCompanies_NoNLCompanies_EmptyList()
        {
            var controller = new CompanyController();
            var companies = new List<ICompany>()
            {
               
                new BeCompany("BE1"),
                new BeCompany("Be2"),
                null,
                new BeCompany("Be3"),
                new BeCompany("BE4"),
               
            };

            var action = controller.GetNlCompanies(companies);

            Assert.Equal(action, new List<NlCompany>());
        }



        [Theory]
        [InlineData(555.5)]
        [InlineData(12399.0)]
        [InlineData(185.44)]
        public void GetRevenueAfterTax_Valid(double revenue)
        {
            var controller = new CompanyController();
            var company = new BeCompany("test");
            var expected = revenue + (revenue / 100 * company.GetVAT());

            var actual = controller.GetRevenueAfterTax(revenue, company);

            Assert.Equal(expected, actual);
        }



    }

}