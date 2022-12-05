using Scheduler.Models.Enum;

namespace Scheduler.Models
{
    public class Aula
    {
        public string Id { get; set; }
        public string AlunoId { get; set; }
        public DateTime DataAula { get; set; }
        public StatusAula Status { get;  set; }
        public DateTime UltimaAlteracao { get;  set; }
    }
}

