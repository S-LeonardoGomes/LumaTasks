using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using Scheduler.Models;
using Scheduler.Services.PublishMessage;

namespace Scheduler.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IConfiguration _configuration;

        public PublisherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PublishMessage(Aula aula, string queueName)
        {
            try
            {
                using (var _connection = new ConnectionFactory()
                {
                    HostName = _configuration["RabbitMQConfiguration:HostName"],
                    Port = AmqpTcpEndpoint.UseDefaultPort,
                    RequestedHeartbeat = TimeSpan.FromSeconds(60)
                }.CreateConnection())
                {
                    using (var _channel = _connection.CreateModel())
                    {
                        _channel.QueueDeclare(
                            queue: queueName,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
                        );

                        var message = JsonSerializer.Serialize(aula);
                        byte[] bytesMessage = Encoding.UTF8.GetBytes(message);

                        _channel.BasicPublish(
                            exchange: "",
                            routingKey: queueName,
                            basicProperties: null,
                            body: bytesMessage
                        );
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
