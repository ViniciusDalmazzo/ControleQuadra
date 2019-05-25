using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    public class Jogador
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
    }
}