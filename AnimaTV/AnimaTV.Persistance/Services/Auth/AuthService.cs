using AnimaTV.Persistance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimaTV.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private protected User _authorizeUser;
        private protected IEnumerable<User> _userList;
        public void RegisterUserList(IEnumerable<User> userList)
        {
            _userList = userList as IEnumerable<User>;
        }

        public User GetCashedUser(string token)
        {
            if (_authorizeUser.Token == token)
            {
                return _authorizeUser;
            }

            throw new OperationCanceledException();
        }
            

        public User GetUserByToken(string token)
        {
            var thisUser = _userList.FirstOrDefault(user => user.Token == token);

            if (thisUser == null)
            {
                throw new NullReferenceException(nameof(thisUser));
            }

            return thisUser;
        }

        public User Auth(string login, string password, bool isSave)
        {
            var user = _userList.FirstOrDefault(u => u.NickName == login && u.Password == password);

            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }

            user.Token = Guid.NewGuid().ToString();


            if (isSave)
            {
                _authorizeUser = user;

                return _authorizeUser;
            }
            else
            {
                return user;
            }
        }

        public bool IsCancelAuth(string idUser)
        {
            if (_authorizeUser.Id == idUser)
            {
                _authorizeUser = null;

                return true;
            }

            return false;
        }
    }
}
