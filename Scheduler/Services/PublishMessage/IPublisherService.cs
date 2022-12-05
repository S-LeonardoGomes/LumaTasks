using Scheduler.Models;

namespace Scheduler.Services.PublishMessage
{
    public interface IPublisherService
    {
        void PublishMessage(Aula aula, string queueName);
    }
}
