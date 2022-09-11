namespace IntermediateToetsTwee.Companies
{
    public interface IUserController
    {
        public List<string> GetCompanyFromUsers(List<IUser> users);
        public List<IUser> GetContactPersonsFromUsers(List<IUser> users);
    }
}