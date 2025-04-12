using System;

namespace OnlineShopping
{
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public Address GetAddress()
        {
            return _address;
        }

        
        public bool LivesInUSA()
        {
            return _address.InUSA();
        }
    }
}
