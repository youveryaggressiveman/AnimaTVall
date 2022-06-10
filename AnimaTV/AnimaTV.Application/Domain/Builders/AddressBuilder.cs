using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimaTV.Application.Domain.Errors;
using AnimaTV.Application.Model;

namespace AnimaTV.Application.Domain.Builders
{
    public class AddressBuilder : CheckError
    {
        protected Address _address;

        public AddressBuilder() => 
            _address = new();

        public AddressBuilder(Address address) =>
            _address = address;

        public Address Build() =>
            _address;

        public AddressBuilder WithID()
        {
            if (!CheckOnNullOrWhiteSpace(new[] {_address.Name, _address.City, _address.Country}))
                _address.ID = new Guid().ToString();
            else
                _address.ID = new Guid().ToString() + _address.Name[0] + _address.City[0] + _address.Country[0];

            return this;
        }

        public AddressBuilder WithAddressName(string name)
        {
            _address.Name = name;

            return this;
        }

        public AddressBuilder WithAddressNumber(string number)
        {
            _address.Number = number;

            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _address.City = city;

            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _address.Country = country;

            return this;
        }
    }
}
