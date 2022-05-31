using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimaTV.Application.CoreSingleton
{
    public static class ServerSingleton
    {
        private static string _serverLink = "https://localhost:44367/api/";

        public static string GetServerLink() =>
            _serverLink;
    }
}
