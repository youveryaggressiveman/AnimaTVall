using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AnimaTV.Application.Controllers.Data;
using AnimaTV.Application.CoreSingleton;
using AnimaTV.Application.Domain.Builders;
using AnimaTV.Application.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimaTV.Application.Controllers.View
{
    public class ProfileViewModel : PageModel
    {
        private readonly UserController _controller;

        private string _addressName;
        private string _addressNumber;
        private string _city;
        private string _country;

        private User _user;
        private Image _image;

        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
            }
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
            }
        }

        public string AddressName
        {
            get => _addressName;
            set
            {
                _addressName = value;
            }
        }

        public string AddressNumber
        {
            get => _addressNumber;
            set
            {
                _addressNumber = value;
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
            }
        }

        public string Country
        {
            get => _country;
            set
            {
                _country = value;
            }
        }

        public ProfileViewModel()
        {
            _controller = new UserController();

            User = new();

            LoadUserInfo();
        }

        public async void UpdateInfo()
        {
            AddressBuilder addressBuilder = new();
            var address = addressBuilder
                .WithAddressName(AddressName)
                .WithAddressNumber(AddressNumber)
                .WithCity(City)
                .WithCountry(Country)
                .WithID()
                .Build();

            UserBuilder userBuilder = new();
            var user = userBuilder
                .RoleID()
                .WithAvatar(Image)
                .WithDescription(User.Description)
                .WithEmail(User.Email)
                .WithFirstName(User.FirstName)
                .WithLastName(User.LastName)
                .WithNickName(User.NickName)
                .WithPassword(User.Password)
                .WithPhone(User.Phone)
                .WithSecondName(User.SecondName)
                .WithID()
                .Build();

            ValidationContext context = new(user);
            List<ValidationResult> results = new();

            if (Validator.TryValidateObject(user, context, results, true))
            {
                if (await _controller.UpdateInfoAboutUser(user, address))
                {

                }
            }
            else
            {
                foreach (var message in results)
                {
                    //Вывод ошибки валидации
                }
            }

        }

        private async void LoadUserInfo()
        {
            try
            {
                var user = await _controller.GetUserByTokenAsync();

                User = user; 

                using (var ms = new MemoryStream(user.Avatar))
                {
                    Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
        }
    }
}
