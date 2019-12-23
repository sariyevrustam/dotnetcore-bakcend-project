using Npgsql;
using ResourceData.Services.Security.JWT;
using ResourceData.Settings;
using ResourceDomainCore.Bus;

namespace ResourceData.Postgresql.PostgresqlRepository.Solid
{
    public class MainPgRepository
    {
        public readonly DbSettings DbSettings;
        public readonly IEventBus bus;
        public NpgsqlCommand Cmd;

        public MainPgRepository(DbSettings _dbSettings, IEventBus _bus)
        {
            DbSettings = _dbSettings;
            bus = _bus;
        }

        public void CreateFunctionCallQuery(string functionName, NpgsqlConnection connection)
        {
            this.Cmd = new NpgsqlCommand(@$"{functionName}", connection);
            this.Cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public NpgsqlConnection CreateConnection()
        {
            string connectionString = DbSettings.GetConnectionString();
            return new NpgsqlConnection(connectionString);           
        }
    }
}
