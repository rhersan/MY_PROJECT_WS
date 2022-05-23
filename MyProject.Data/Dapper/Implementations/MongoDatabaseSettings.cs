using MyProject.Data.Dapper.Interfaces;

namespace MyProject.Data.Dapper.Implementations
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
