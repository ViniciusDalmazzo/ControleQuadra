using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        
        public string Nome { get; set; }

    }
}