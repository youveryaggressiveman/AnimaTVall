using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Persistance.Mongo
{
    public static class DocumentSingleton
    {
        private readonly static string s_connectionLink = "";

        public static string GetConnectionLink() =>
           s_connectionLink;
    }
}
