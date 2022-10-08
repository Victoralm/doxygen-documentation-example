using doxygen_documentation_example.Data.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace doxygen_documentation_example.Data
{
    public class Context
    {
        //private SqliteConnection _conn;
        private IConfiguration _config;
        //private string _connString;

        //private readonly IConfiguration _config;

        public Context(IConfiguration config)
        {
            this._config = config;
            //this._conn = conn;
            //this._connString = this._config.GetConnectionString("Default").ToString();
        }

        //internal SqliteConnection GetDbConnection()
        //{
        //    this._conn = new SqliteConnection(this._connString);

        //    return this._conn;
        //}

        public IDbConnection GetDbConnection() => new SqliteConnection(_config.GetConnectionString("Default"));
    }
}
