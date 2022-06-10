using AnimaTV.Persistance.Entity;

namespace AnimaTV.Persistance.Services
{
    public interface IAuthService
    {
        public User Auth(string login, string password, bool isSave);
        public bool IsCancelAuth(string idUser);
    }
}
