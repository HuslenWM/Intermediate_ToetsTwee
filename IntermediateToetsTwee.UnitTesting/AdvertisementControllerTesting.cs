using IntermediateToetsTwee.Advertisements;

namespace IntermediateToetsTwee.UnitTesting
{
    public class AdvertisementControllerTesting
    {

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetIOnlineAdvertisements_AdvertisementsEmptyOrNull_ThrowsException(bool needsNull)
        {
            var controller = new AdvertisementController();
            var advertisements = needsNull ? null : new List<IAdvertisement>();

            Assert.Throws<Exception>(() => controller.GetIOnlineAdvertisements(advertisements));
        }

        [Fact]
        public void GetIOnlineAdvertisements_Valid_ListIOnlineAdvertisements()
        {
            var controller = new AdvertisementController();
            var socialMediaPost = new SocialMediaPost();
            var banner = new Banner();
            var expectedAds = new List<IOnlineAdvertisement>()
            {
                 socialMediaPost,
                 banner
            };

            var advertisements = new List<IAdvertisement>()
            {
                new Advertisement(),
                socialMediaPost,
                new Billboard(new Location("street", 2, "XXXX")),
                null,
                banner
            };


            var actualAds = controller.GetIOnlineAdvertisements(advertisements);

            Assert.Equal(expectedAds, actualAds);
        }

        [Fact]
        public void GetBillboardsLocations_Valid_List()
        {
            var controller = new AdvertisementController();
           
            var billboard = new Billboard(new Location("Street", 5, "1123"));
            var expected = billboard.Location;
            var advertisements = new List<IAdvertisement>()
            {
                new Banner(),
                new SocialMediaPost(),
                new Advertisement(),
                billboard
            };

            var actual = controller.GetBillboardsLocations(advertisements);

            Assert.Equal(expected, actual[0]);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetGuidsFromAdvertisements_ListIsNullOrEmpty_ThrowsException(bool needsNull)
        {
            // Arrange
            var controller = new AdvertisementController();
            var advertisements = needsNull ? null : new List<IAdvertisement>();

            // Assert & act
            Assert.Throws<Exception>(() => controller.GetGuidsFromAdvertisements(advertisements));
        }

        [Fact]
        public void GetGuidsFromAdvertisements_Valid_ListGuids()
        {

            var controller = new AdvertisementController();
            var expected = new Banner();

            var advertisements = new List<IAdvertisement>()
            {
                new Banner(),
                new SocialMediaPost(),
                expected
            };

            var actual = controller.GetGuidsFromAdvertisements(advertisements);

            Assert.Equal(expected.Guid, actual[2]);

        }

    }
}