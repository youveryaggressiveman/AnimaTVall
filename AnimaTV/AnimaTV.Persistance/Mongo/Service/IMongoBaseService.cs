using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Persistance.Mongo.Service
{
    public interface IMongoBaseService<T> where T: class, IDocument
    {
        IQueryable<T> GetAll();
        Task<T> Put(T document);
        Task<T> Create(T document);
        Task Delete(string id);

        IMongoCollection<T> GetCollection();
    }
}
