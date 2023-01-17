using MongoDB.Bson;
using System.Text.Json;

namespace Labb_MongoDB
{
    internal interface ICRUDOperationsDAO
    {
        public List<ProductODM> GetAll();
        public List<ProductODM> GetOne(string filter);
        public void Create(ProductODM product);
        public void Update(ObjectId id, ProductODM updatedProduct);
        public void Delete(ObjectId id);
    }
}

//public List<BsonDocument> GetAll();
//public List<BsonDocument> GetOne(string filter);
//public void Create(BsonDocument document);
//public void Update(int id);
//public void Delete(int id);

