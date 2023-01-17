using Labb_MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Labb_MongoDB
{
    internal class MongoDAO : ICRUDOperationsDAO
    {
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<ProductODM> collection;

        public MongoDAO(string connectionString, string databaseString)
        {
            this.dbClient = new MongoClient(connectionString);
            this.database = this.dbClient.GetDatabase(databaseString);
            collection = this.database.GetCollection<ProductODM>("games");
        }

        public void Create(ProductODM product)
        {
            collection.InsertOne(product);
        }

        public void Delete(ObjectId id)
        {
            var filter = Builders<ProductODM>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        public List<ProductODM> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public List<ProductODM> GetOne(string filter)
        {
            return collection.Find(Builders<ProductODM>.Filter.Regex("name", new BsonRegularExpression($"(?i).*{filter}.*"))).ToList();
        }

        public void Update(ObjectId id, ProductODM product)
        {
            var filter = Builders<ProductODM>.Filter.Eq("Id", id);
            var update = Builders<ProductODM>.Update
                .Set("Name", product.Name)
                .Set("Type", product.Type)
                .Set("Price", product.Price)
                .Set("Quantity", product.Quantity)
                .Set("Description", product.Description);
            collection.UpdateOne(filter, update);
        }
    }
}



//public void Create(BsonDocument document)
//{
//    collection.InsertOne(document);
//}

//public void Create(ProductODM product)
//{

//}

//public void Delete(int id)
//{
//    var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
//    collection.DeleteOne(filter);
//}

//public List<BsonDocument> GetAll()
//{
//    var post = collection.Find(_ => true).ToList();
//    return post.ToList();
//}

//List<ProductODM> GetAll()
//{

//}

//public List<BsonDocument> GetOne(string filter)
//{
//    return collection.Find(Builders<BsonDocument>.Filter.Regex("name", new BsonRegularExpression($"(?i).*{filter}.*"))).ToList();
//}

//public void Update(int id)
//{

//}

//public void UpdateProduct(int ID, string column, string input)
//{
//    //var filter = Builders<BsonDocument>.Filter.Eq("_id", ID);
//    //var update = Builders<BsonDocument>.Update.Set(column, input);
//    //collection.UpdateOne(filter, update);
//}
