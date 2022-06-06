using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaTV.Core.Data.Model;

namespace AnimaTV.Core.Services.Data.CRUD.User
{
    public class UserWorkHelper : IDatabaseService<Core.Data.Model.User>
    {
        private readonly IEnumerable<Core.Data.Model.User> _userSqlList;
        private readonly List<Core.Data.Model.User> _userMongoList;

        public UserWorkHelper(IEnumerable<Core.Data.Model.User> userSqlList, List<Core.Data.Model.User> userMongoList) =>
            (_userSqlList, _userMongoList) = (userSqlList, userMongoList);

        public UserWorkHelper(IEnumerable<Core.Data.Model.User> userSQLList) : this(userSQLList, null){}

        public UserWorkHelper(List<Core.Data.Model.User> userMongoList) : this(null, userMongoList) { }


        public IEnumerable<Core.Data.Model.User> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Core.Data.Model.User Delete(string id)
        {
            var user = _userSqlList.FirstOrDefault(user => user.Id == id);

           if (user == null)
           {
               throw new NullReferenceException(nameof(user));
           }

            return user;
        }

        public Core.Data.Model.User Put(string id)
        {
            var user = _userSqlList.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }

            return user;
        }

        public Core.Data.Model.User Create(Core.Data.Model.User target)
        {
            throw new NotImplementedException();
        }

        public Core.Data.Model.User UpdateUserInfo(Core.Data.Model.User user, string mongoAddressId)
        {
            user.AddressId = mongoAddressId;

            return user;
        }

        public bool CheckAvailabilityPassword(string password)
        {
            var user = _userSqlList.FirstOrDefault(u => u.Password == password);

            if (user == null)
            {
                return true;
            }

            return false;
        }
    }
}
