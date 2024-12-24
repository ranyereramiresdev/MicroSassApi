using Dapper;
using MicroSassApi.Models;
using MicroSassApi.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace MicroSassApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MySqlConnection _database;
        public UserRepository(MySqlConnection database)
        {
            _database = database;
            if (!(_database.State == System.Data.ConnectionState.Open))
            {
                _database.Open();
            }
        }

        public async Task<UsuarioModel?> LoginAsync(string email, string senha)
        {
            try
            {
                const string query = @"
                SELECT 
                    Id,
                    Email,
                    Senha,
                    IdTipoUsuario,
                    IdResponsavel
                FROM Usuario
                WHERE Email = @Email AND Senha = @Senha";

                var user = await _database.QueryFirstOrDefaultAsync<UsuarioModel>(query, new { Email = email, Senha = senha });
                _database.Close();

                return user;
            }
            catch
            {
                _database.Close();
                throw;
            }
        }

        public async Task Add(UsuarioModel usuario)
        {
            try
            {
                const string query = @"
                insert into Usuario
                (Email, Senha, IdTipoUsuario, IdResponsavel)
                values
                (@Email, @Senha, @IdTipoUsuario, @IdResponsavel)";

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Email", usuario.Email);
                dynamicParameters.Add("@Senha", usuario.Senha);
                dynamicParameters.Add("@IdTipoUsuario", usuario.IdTipoUsuario);
                dynamicParameters.Add("@IdResponsavel", usuario.IdResponsavel);

                await _database.ExecuteAsync(query, dynamicParameters);

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
