using LumaTasks.Models;

namespace LumaTasks.Repository.Interfaces
{
    public interface IAulaRepository
    {
        IEnumerable<Aula> GetAulas();
        Aula GetAulaById(string id);
        void ScheduleAula(Aula aula);
        void UpdateEvent(Aula aula);
    }
}
