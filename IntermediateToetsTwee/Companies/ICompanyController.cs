namespace IntermediateToetsTwee.Companies
{
    public interface ICompanyController
    {
        public object[] SortCompaniesByCountry(List<ICompany> companies);
        public List<NlCompany> GetNlCompanies(List<ICompany> companies);
        public List<BeCompany> GetBeCompanies(List<ICompany> companies);
        public double GetRevenueAfterTax(double revenue, ICompany company);


    }
}