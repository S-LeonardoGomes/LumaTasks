using System.ComponentModel.DataAnnotations;

namespace LumaTasks.Models
{
    public class Aluno
    {
        [Key]
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
