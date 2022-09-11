namespace IntermediateToetsTwee.Companies
{
    internal interface ICompanyController
    {
        // public List<List<ICompany>> SortCompaniesByCountry(List<ICompany> companies);
        public List<NlCompany> GetNlCompanies(List<ICompany> companies);
        public List<BeCompany> GetBeCompanies(List<ICompany> companies);
        public double GetRevenueAfterTax(double revenue, ICompany company);


    }
}