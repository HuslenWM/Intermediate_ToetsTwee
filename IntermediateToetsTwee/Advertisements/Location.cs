namespace IntermediateToetsTwee.Advertisements
{
    public class Location
    {
        public Location(string streetName, int houseNumber, string zipCode)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
        }
        public override string ToString() => $"{StreetName} - {HouseNumber} - {ZipCode}";
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
       

    }
}