using System;
using System.Collections.Generic;

namespace IntermediateToetsTwee.Companies
{
    public class CompanyController : ICompanyController
    {
        public object[] SortCompaniesByCountry(List<ICompany> companies)
        {
            if (companies == null || !companies.Any())
            {
                throw new Exception("Companies is null or empty");
            }
            //var sortedCompanies = new List<List<NlCompany>,List<BeCompany>>();

            var sortedCompanies = new object[2];

            var nlCompanies = GetNlCompanies(companies);
            var beCompanies = GetBeCompanies(companies);

            sortedCompanies[0] = nlCompanies;
            sortedCompanies[1] = beCompanies;

            return sortedCompanies;
        }

        public List<NlCompany> GetNlCompanies(List<ICompany> companies)
        {
            if (companies == null || !companies.Any())
            {
                throw new Exception("Companies is null or empty");
            }

            var nlCompanies = new List<NlCompany>();
            foreach (var company in companies)
            {
                if (company is NlCompany)
                {
                    nlCompanies.Add((NlCompany)company);
                }
            }
            return nlCompanies;
        }

        public List<BeCompany> GetBeCompanies(List<ICompany> companies)
        {
            if (companies == null || !companies.Any())
            {
                throw new Exception("Companies is null or empty");
            }

            var beCompanies = new List<BeCompany>();
            foreach (var company in companies)
            {
                if (company is BeCompany)
                {
                    beCompanies.Add((BeCompany)company);
                }
            }
            return beCompanies;
        }
        public double CalculateCompanyTax(double value, Company company)
        {
            if (company == null)
            {
                throw new Exception("Company is null");
            }

            return value + value / 100 * company.GetVAT();
        }

        public double GetRevenueAfterTax(double revenue, ICompany company)
        { 
            if (company == null)
            {
                throw new Exception("Company is null");
            }
            return revenue + (revenue / 100 * company.GetVAT());
        }
    }
}