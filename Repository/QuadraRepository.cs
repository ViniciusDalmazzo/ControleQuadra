using System.Collections.Generic;
using ApiMySql.Model;
using MySql.Data.MySqlClient;
using Dapper;

namespace ApiMySql.Repository
{
    public class QuadraRepository : IQuadraRepository
    {
        private readonly string _connectionString;

        public QuadraRepository(string connectionString)
        {
            _connectionString = connectionString;  
        }

        public void Add(Quadra Quadra)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Query($"INSERT INTO {connection.Database}.Quadra(Nome, Endereco) VALUES('{Quadra.Nome}', '{Quadra.Endereco}')");
            }
        }

        public IEnumerable<Quadra> GetAll()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {               
                return connection.Query<Quadra>($"SELECT Id, Nome, Endereco FROM {connection.Database}.Quadra ORDER BY Nome ASC");
            }
        }
    }
}