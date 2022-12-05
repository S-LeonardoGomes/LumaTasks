using LumaTasks.Models;
using LumaTasks.Models.Enum;

namespace LumaTasks.Services.Interfaces
{
    public interface IAulaService
    {
        IEnumerable<Aula> GetAulas();
        Aula GetAulaById(string id);
        void ScheduleEvent(Aula aula);
        void UpdateEvent(Aula aula);
    }
}
