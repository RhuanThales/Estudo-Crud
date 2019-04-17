using MongoDB.Driver;

namespace estudo_crud.DataAccess.Models
{
    public interface IMongoContext
    {
        IMongoCollection<Livro> CollectionLivro { get; }
    }
}