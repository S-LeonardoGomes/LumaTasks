using LumaTasks.Models;

namespace LumaTasks.Services.Interfaces
{
    public interface IPublishService
    {
        void PublishMessage(Aula aula, string queueName);
    }
}
