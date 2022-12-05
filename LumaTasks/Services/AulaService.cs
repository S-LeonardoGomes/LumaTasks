using LumaTasks.Models;
using LumaTasks.Models.Enum;
using LumaTasks.Repository.Interfaces;
using LumaTasks.Services.Interfaces;

namespace LumaTasks.Services
{
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _aulaRepository;
        private readonly IPublishService _publishService;

        public AulaService(IAulaRepository aulaRepository, IPublishService publishService)
        {
            _aulaRepository = aulaRepository;
            _publishService = publishService;
        }

        public IEnumerable<Aula> GetAulas()
        {
            try
            {
                return _aulaRepository.GetAulas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Aula GetAulaById(string id)
        {
            try
            {
                return _aulaRepository.GetAulaById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ScheduleEvent(Aula aula)
        {
            try
            {
                _aulaRepository.ScheduleAula(aula);
                _publishService.PublishMessage(aula, "AGENDAR_AULA");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEvent(Aula aula)
        {
            try
            {
                _aulaRepository.UpdateEvent(aula);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
