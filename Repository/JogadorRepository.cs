using System.Collections.Generic;
using ApiMySql.Model;
using MySql.Data.MySqlClient;
using Dapper;

namespace ApiMySql.Repository
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly string _connectionString;

        public JogadorRepository(string connectionString)
        {
            _connectionString = connectionString;  
        }

        public void Add(Jogador jogador)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Query($"INSERT INTO projetoquara.Jogador(Nome, Sobrenome) VALUES('{jogador.Nome}', '{jogador.Sobrenome}')");
            }
        }

        public IEnumerable<Jogador> GetAll()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {               
                return connection.Query<Jogador>("SELECT Id, Nome, Sobrenome FROM Jogador ORDER BY Nome ASC");
            }
        }
    }
}