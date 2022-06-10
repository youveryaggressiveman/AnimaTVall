using AnimaTV.Persistance.Mongo.Service;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Persistance.Mongo.Model
{
    public class Address : IDocument
    {
        public ObjectId ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
