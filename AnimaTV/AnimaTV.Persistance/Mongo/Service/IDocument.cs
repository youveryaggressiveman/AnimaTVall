using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Persistance.Mongo.Service
{
    public interface IDocument
    {
        ObjectId ID { get; set; }
    }
}
