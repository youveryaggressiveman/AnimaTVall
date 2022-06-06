using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AnimaTV.Application.Domain.Errors;
using AnimaTV.Application.Model;

namespace AnimaTV.Application.Domain.Builders
{
    public class UserBuilder : CheckError
    {
        protected User _user;

        public UserBuilder() => 
            _user = new();

        public UserBuilder(User user) =>
            _user = user;

        public User Build() =>
            _user;

        public UserBuilder WithID()
        {
            if (!CheckOnNullOrWhiteSpace(new[] { _user.NickName, _user.Phone }))
                _user.FirstName = new Guid().ToString();
            else
                _user.Id = new Guid().ToString() + _user.NickName[0] + _user.Phone[1];

            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            _user.FirstName = firstName;

            return this;
        }

        public UserBuilder WithSecondName(string secondName)
        {
            _user.SecondName = secondName;

            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            _user.LastName = lastName;

            return this;
        }

        public UserBuilder WithPhone(string phone)
        {
            _user.Phone = phone;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public UserBuilder WithNickName(string nickName)
        {
            _user.NickName = nickName;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _user.Password = password;
            return this;
        }

        public UserBuilder WithAddressID(string addressID)
        {
            _user.AddressId = addressID;
            return this;
        }

        public UserBuilder WithAvatar(Image avatar)
        {
            ImageConverter converter = new();

            _user.Avatar = (byte[])converter.ConvertTo(avatar, typeof(byte[]));
            return this;
        }

        public UserBuilder WithToken(string token)
        {
            _user.Token = token;
            return this;
        }

        public UserBuilder WithDescription(string description)
        {
            _user.Description = description;

            return this;
        }

        public UserBuilder WithRate(string rate)
        {
            _user.Rate = rate;
            return this;
        }

        public UserBuilder RoleID()
        {
            _user.RoleId = "";
            return this;
        }
    }
}
