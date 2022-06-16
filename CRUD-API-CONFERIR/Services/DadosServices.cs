using CRUD_API_CONFERIR.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CRUD_API_CONFERIR.Services
{
    public class DadosServices
    {
        private readonly IMongoCollection<Dados> _dadosCollection;
        
        public DadosServices(
            IOptions<DadosDatabaseSettings> dadosDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                dadosDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                dadosDatabaseSettings.Value.DatabaseName);
            _dadosCollection = mongoDatabase.GetCollection<Dados>(
                dadosDatabaseSettings.Value.DadosCollectionName);

        }

        public async Task<List<Dados>> GetAsync() =>
            await _dadosCollection.Find(_=> true).ToListAsync();

        public async Task<Dados?> GetAsync(string cpf) =>
            await _dadosCollection.Find(x => x.Cpf == cpf).FirstOrDefaultAsync();

        public async Task CreateAsync(Dados newDados)
            
        { 
            var dadosfound = await _dadosCollection
                .Find(x => x.Cpf == newDados.Cpf || x.Email == newDados.Email)
                .FirstOrDefaultAsync();

            if (dadosfound != null)
            {
                throw new Exception("O email ou Cpf informado já possuí um cliente");
            }
            await _dadosCollection.InsertOneAsync(newDados); 
        
        }

        public async Task UpdateAsync(string cpf, Dados updateDados) =>
            await _dadosCollection.ReplaceOneAsync(x => x.Cpf == cpf, updateDados);

        public async Task RemoveAsync(string cpf) =>
        await _dadosCollection.DeleteOneAsync(x => x.Cpf == cpf);
    }
}
