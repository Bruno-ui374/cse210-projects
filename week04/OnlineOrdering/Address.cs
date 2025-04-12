using System;

namespace OnlineShopping
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;

        public Address(string street, string city, string state, string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _country = country;
        }

        // Determines if the address is in the USA.
        public bool InUSA()
        {
            return _country.ToUpper() == "USA";
        }

        // Returns the full address as a formatted string.
        public string GetFullAddress()
        {
            return _street + "\n" + _city + ", " + _state + "\n" + _country;
        }
    }
}
