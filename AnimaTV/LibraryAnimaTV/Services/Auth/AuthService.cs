using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaTV.Core.Data.Model;

namespace AnimaTV.Core.Services
{
    public class AuthService : IAuthService
    {
        public User GetUserByToken(string token)
        {
            throw new NotImplementedException();
        }

        public string Auth(string login, string password, bool isSave)
        {
            throw new NotImplementedException();
        }

        public string IsCancelAuth(string isUser)
        {
            throw new NotImplementedException();
        }
    }
}
