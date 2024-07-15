namespace Domain.ValueObjects
{
    public class Address : BaseValueObject<int>
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Voivodeship { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public Address() { }

        public Address(string street, string city, string voivodeship, string country, string zipcode)
        {
            Street = street;
            City = city;
            Voivodeship = voivodeship;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return Voivodeship;
            yield return Country;
            yield return ZipCode;
        }
    }
}

