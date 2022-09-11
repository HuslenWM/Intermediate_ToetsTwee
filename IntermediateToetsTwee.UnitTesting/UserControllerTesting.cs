using IntermediateToetsTwee.Companies;
using IntermediateToetsTwee.Advertisements;

namespace IntermediateToetsTwee.UnitTesting
{
    public class UserControllerTesting
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetCompanyFromUsers_UsersNullOrEmpty_ThrowException(bool needsNull)
        {
            var controller = new UserController();
            
            var users = needsNull ? null : new List<IUser>() { };

            // Assert
            Assert.Throws<Exception>(() => controller.GetCompanyFromUsers(users));
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetContactPersonsFromUsers_UsersNullOrEmpty_ThrowsException(bool needsNull)
        {
            var controller = new UserController();
            var users = needsNull ? null : new List<IUser>();

            Assert.Throws<Exception>(()=> controller.GetContactPersonsFromUsers(users));
        }

        [Fact]
        public void GetContactPersonsFromUsers_Valid()
        {
            var controller = new UserController();
            var companyA = new NlCompany("companyA");
            var expected = new User("ContactPersonA", "@live.com", new Location("b",1,"a") ,companyA);
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

            Assert.Equal(expected, actual[0]);
        }
    }
}