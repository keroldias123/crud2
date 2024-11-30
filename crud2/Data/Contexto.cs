using crud2.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace crud2.Data
{
    public class Contexto
    {
        private readonly string _connectionString = "Server=localhost;Database=crud2;Uid=root;Pwd=;";

        public async Task<List<PessoaModel>> GetAllPessoasAsync()
        {
            var pessoas= new List<PessoaModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString)) 
                {
                   
                    await connection.OpenAsync(); // versão assíncrona
                    var command = new MySqlCommand("SELECT * FROM pessoa", connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        { 
                            pessoas.Add(new PessoaModel { Id = reader.GetInt32("id"), Nome=reader.GetString("Nome"), Idade=reader.GetInt32("Idade") });
                        
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar pessoas: {ex.Message}");
            }
            return pessoas;
        }

        public async Task<PessoaModel> GetPessoaByIdAsync(int id)
        {
            PessoaModel pessoa = null;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new MySqlCommand("SELECT * FROM pessoa WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            pessoa = new PessoaModel
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Idade = reader.GetInt32("Idade")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar pessoa: {ex.Message}");
            }

            return pessoa;
        }

        public async Task AddPessoaAsync(PessoaModel pessoa)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new MySqlCommand("INSERT INTO pessoa (Nome, Idade) VALUES (@Nome, @Idade)", connection);
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Idade", pessoa.Idade);
                    await command.ExecuteNonQueryAsync(); // Versão assíncrona
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar pessoa: {ex.Message}");
            }
        }

        public async Task UpdatePessoaAsync(PessoaModel pessoa)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new MySqlCommand("UPDATE pessoa SET Nome = @Nome, Idade = @Idade WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Idade", pessoa.Idade);
                    command.Parameters.AddWithValue("@Id", pessoa.Id);
                    await command.ExecuteNonQueryAsync(); // Versão assíncrona
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar pessoa: {ex.Message}");
            }
        }

        public async Task DeletePessoaAsync(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new MySqlCommand("DELETE FROM pessoa WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync(); // Versão assíncrona
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir pessoa: {ex.Message}");
            }
        }



    }
}

