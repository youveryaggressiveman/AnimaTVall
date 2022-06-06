namespace AnimaTV.Core.Data.Model
{
    public class User
    {
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
    }

}
