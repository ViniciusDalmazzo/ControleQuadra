using System.Collections.Generic;
using ApiMySql.Model;
using MySql.Data.MySqlClient;
using Dapper;
using System.Net;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ApiMySql.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly string _connectionString;

        public AgendamentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ReserveResponseDTO Add(Agendamento Agendamento)
        {
            ReserveResponseDTO reserveResponseDTO = new ReserveResponseDTO();
            string URL = "http://127.0.0.1:5002/reserve";
            
            string DATA = JsonConvert.SerializeObject(Agendamento);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();

                    reserveResponseDTO = JsonConvert.DeserializeObject<ReserveResponseDTO>(response);
                }
            }
            catch
            {
                reserveResponseDTO.status = false;
            }

            return reserveResponseDTO;
        }

        public IEnumerable<Agendamento> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Agendamento>($"SELECT IdQuadra, IdGrupo, DataInicio, DataFim FROM {connection.Database}.Agendamento ORDER BY IdQuadra ASC");
            }
        }
    }
}