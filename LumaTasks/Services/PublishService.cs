using LumaTasks.Models;
using LumaTasks.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace LumaTasks.Services
{
    public class PublishService : IPublishService
    {
        private readonly IConfiguration _configuration;

        public PublishService(IConfiguration configuration)
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
            catch(Exception)
            {
                throw;
            }
        }
    }
}
