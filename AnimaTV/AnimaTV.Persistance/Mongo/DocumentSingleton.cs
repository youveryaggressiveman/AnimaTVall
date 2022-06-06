using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Persistance.Mongo
{
    public static class DocumentSingleton
    {
        private readonly static string s_connectionLink = "mongodb://Admin:Bdc%406!@mongo.codehub.awkitsune.icu:27017/";
        private readonly static string s_database = "animatv_data";

        public static string GetDatabase() =>
            s_database;

        public static string GetConnectionLink() =>
           s_connectionLink;
    }
}
