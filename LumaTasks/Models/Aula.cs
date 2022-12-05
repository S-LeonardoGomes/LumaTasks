using LumaTasks.Models.Enum;

namespace LumaTasks.Models
{
    public class Aula
    {
        public string Id { get; set; }
        public string AlunoId { get; set; }
        public DateTime DataAula { get; set; }
        public StatusAula StatusAula { get; private set; } = 0;
        public DateTime UltimaAlteracao { get; private set; } = DateTime.Now;

        public void AtualizarStatus(StatusAula status)
        {
            StatusAula = status;
            UltimaAlteracao = DateTime.Now;
        }
    }
}
