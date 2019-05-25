using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    public class Grupo
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public string Nome { get; set; }

    }
}