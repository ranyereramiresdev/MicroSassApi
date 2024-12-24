using Dapper;
using MicroSassApi.Models;
using MicroSassApi.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace MicroSassApi.Repositories
{
    public class UserTypeRepository:IUserTypeRepository
    {
        private MySqlConnection _database;
        public UserTypeRepository(MySqlConnection database)
        {
            _database = database;
            if (!(_database.State == System.Data.ConnectionState.Open))
            {
                _database.Open();
            }
        }

        public async Task Add(TipoUsuarioModel tipoUsuario)
        {
            try
            {
                const string query = @"
                INSERT INTO TipoUsuario (Descricao)
                VALUES (@Descricao);";

                await _database.ExecuteAsync(query, new { Descricao = tipoUsuario.Descricao });

                _database.Close();
            }
            catch
            {
                _database.Close();
                throw;
            }
        }
    }
}
