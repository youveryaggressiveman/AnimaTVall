using System.Collections.Generic;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class User
    {
        public User()
        {
            UserOfSubscriptions = new HashSet<UserOfSubscription>();
            UserOfVideos = new HashSet<UserOfVideo>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string AddressId { get; set; }
        public byte[] Avatar { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<UserOfSubscription> UserOfSubscriptions { get; set; }
        public virtual ICollection<UserOfVideo> UserOfVideos { get; set; }

        public static implicit operator AnimaTV.Core.Data.Model.User(User user)
        {
            return new AnimaTV.Core.Data.Model.User
            {
                NickName = user.NickName,
                Password = user.Password
            };
        }
    }
}
