using System.Collections.Generic;
using ApiMySql.Model;
using MySql.Data.MySqlClient;
using Dapper;

namespace ApiMySql.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly string _connectionString;

        public GrupoRepository(string connectionString)
        {
            _connectionString = connectionString;  
        }

        public void Add(Grupo Grupo)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Query($"INSERT INTO {connection.Database}.Grupo(Nome) VALUES('{Grupo.Nome}')");
            }
        }

        public void AddGrupoJogador(GrupoJogadorDTO grupoJogador)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                foreach (var id in grupoJogador.IdJogadores)
                {
                    connection.Query($"INSERT INTO {connection.Database}.GrupoJogador(IdJogador, IdGrupo) VALUES('{id}', '{grupoJogador.IdGrupo}')");
                }

            }
        }

        public IEnumerable<Grupo> GetAll()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {               
                return connection.Query<Grupo>($"SELECT Id, Nome FROM {connection.Database}.Grupo ORDER BY Nome ASC");
            }
        }
    }
}