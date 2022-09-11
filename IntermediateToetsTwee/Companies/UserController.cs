namespace IntermediateToetsTwee.Companies
{
    public class UserController : IUserController
    {
        public List<string> GetCompanyFromUsers(List<IUser> users)
        {
            if (users == null || !users.Any())
            {
                throw new Exception("Users is null or empty");
            }

            var companyUsers = new List<string>();

            foreach (var user in users)
            {
                companyUsers.Add($"[{user.UserName}] works at [{user.Company}]");
            }
            return companyUsers;
            
        }

        public List<IUser> GetContactPersonsFromUsers(List<IUser> users)
        {
            if (users == null || !users.Any())
            {
                throw new Exception("Users is null");
            }
            var contactPersons = new List<IUser>();
     
            foreach (var user in users)
            {
                if (user.Equals(user.Company.ContactPerson))
                {
                    contactPersons.Add(user);
                }  
            };
            return contactPersons;
        }


    }
}