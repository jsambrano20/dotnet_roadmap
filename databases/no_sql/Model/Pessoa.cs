using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace no_sql.Model
{
    public class Pessoa
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }
}
