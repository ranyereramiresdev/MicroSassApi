using Dapper;
using MicroSassApi.Models;
using MicroSassApi.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace MicroSassApi.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private MySqlConnection _database;
        public ResponsibleRepository(MySqlConnection database)
        {
            _database = database;
            if (!(_database.State == System.Data.ConnectionState.Open))
            {
                _database.Open();
            }
        }

        public async Task Add(ResponsavelModel reponsible)
        {
            try
            {
                const string query = @"
                INSERT INTO Responsavel (Descricao)
                VALUES (@Descricao);";

                await _database.ExecuteAsync(query, new { Descricao = reponsible.Descricao });

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
