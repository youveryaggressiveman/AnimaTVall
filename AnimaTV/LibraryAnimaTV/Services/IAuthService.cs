using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Core.Services
{
    public interface IAuthService
    {
        public string Auth(string login, string password, bool isSave);
        public string IsCancelAuth(string isUser);
    }
}
