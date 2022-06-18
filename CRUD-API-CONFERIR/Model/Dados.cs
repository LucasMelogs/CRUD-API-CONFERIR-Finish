using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_API_CONFERIR.Model
{
    public class Dados
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("E-mail")]
        public string Email { get; set; } = null!;

        [BsonElement("Telefone")]
        public string Telefone { get; set; } = null!;

        [BsonElement("CNPJ/CPF")]
        public string Cpf { get; set; } = null!;

        [BsonElement("Endereço")]
        public string Endereço { get; set; } = null!;

        [BsonElement("Status")]
        public bool Active { get; set; } = true;





    }
}
