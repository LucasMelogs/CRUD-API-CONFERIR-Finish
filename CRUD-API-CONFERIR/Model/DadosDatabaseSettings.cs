namespace CRUD_API_CONFERIR.Model
{
    public class DadosDatabaseSettings
    {

        public string ConnectionString { get; set; } = null!;
        
        public string DatabaseName { get; set; } = null!;

        public string DadosCollectionName { get; set; } = null!;
    }
}