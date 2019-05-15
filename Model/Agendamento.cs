using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    public class Agendamento
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        [JsonProperty("quadra")]
        public int IdQuadra { get; set; }

        [JsonProperty("grupo")]
        public int IdGrupo { get; set; }

        [JsonProperty("dataInicio")]
        public DateTime DataInicio { get; set; }

        [JsonProperty("dataFim")]
        public DateTime DataFim { get; set; }

    }
}