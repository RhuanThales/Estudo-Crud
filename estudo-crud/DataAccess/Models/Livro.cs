using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace estudo_crud.DataAccess.Models
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdLivro { get; set; }

        [BsonElement("Nome")]
        public string NomeLivro { get; set; }
        
        [BsonElement("Valor")]
        public string ValorLivro { get; set; }
        
        [BsonElement("Tipo")]
        public string TipoLivro { get; set; }
        
        [BsonElement("Autor")]
        public string AutorLivro { get; set; }
    }
}