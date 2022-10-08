using doxygen_documentation_example.Data.Models;
using Microsoft.Data.Sqlite;
using System.Data;
using static Dapper.SqlMapper;

namespace doxygen_documentation_example.Data
{
    public class Context
    {
        private IConfiguration _config;

        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public Context(IConfiguration config)
        {
            this._config = config;
            _id = Guid.NewGuid();
            Connection = new SqliteConnection(_config.GetConnectionString("Default"));
            Connection.Open();
        }

        public IDbConnection GetDbConnection() => new SqliteConnection(_config.GetConnectionString("Default"));

        public void Dispose() => Connection?.Dispose();
    }
}
