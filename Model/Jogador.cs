using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    public class Jogador
    {
        [Key]
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
    }
}