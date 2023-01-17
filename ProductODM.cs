using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Labb_MongoDB
{
    internal class ProductODM
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }

        public ProductODM(string name, string type, int price, int quantity, string description)
        {
            Name = name;
            Type = type;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
    }
}
