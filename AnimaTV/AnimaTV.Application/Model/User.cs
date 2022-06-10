using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AnimaTV.Application.Domain.Builders;

namespace AnimaTV.Application.Model
{
    public class User
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        [Phone(ErrorMessage = "Поле phone не удовлетворяет условию")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Поле email не удовлетворяет условию")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле nickname не может быть пустым")]
        public string NickName { get; set; }
        [MinLength(8, ErrorMessage = "Поле password должно содержать не меньше 8 символов")]
        [Required(ErrorMessage = "Поле password не может быть пустым")]
        public string Password { get; set; }
        public string AddressId { get; set; }
        public byte[] Avatar { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
