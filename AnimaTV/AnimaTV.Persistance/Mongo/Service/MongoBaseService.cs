using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Persistance.Mongo.Service
{
    public class MongoBaseService<T> : IMongoBaseService<T> where T : class, IDocument
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private IMongoCollection<T> _targetCollection;

        public MongoBaseService(IMongoClient client, string db, string collection)
        {
            _client = client;
            _database = _client.GetDatabase(db);
            _targetCollection = _database.GetCollection<T>(collection);
        }

        public async Task<T> Create(T document)
        {
            await _targetCollection.InsertOneAsync(document);
            return document;
        }

        public async Task Delete(string id)
        {
            await _targetCollection.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }

        public IQueryable<T> GetAll()
        {
            return _targetCollection.AsQueryable();
        }

        public IMongoCollection<T> GetCollection()
        {
            return _targetCollection;
        }

        public async Task<T> Put(T document)
        {
            await _targetCollection.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(document.ID.ToString())), document);
            return document;
        }
    }
}
