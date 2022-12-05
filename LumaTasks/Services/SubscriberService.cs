using LumaTasks.Models;
using LumaTasks.Models.Enum;
using LumaTasks.Services.Interfaces;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace LumaTasks.Services
{
    public class SubscriberService : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public SubscriberService(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            string hostName = configuration["RabbitMQConfiguration:HostName"];
            _serviceProvider = serviceProvider;
            ConnectionFactory factory = new()
            {
                HostName = hostName,
                Port = AmqpTcpEndpoint.UseDefaultPort,
                RequestedHeartbeat = TimeSpan.FromSeconds(60),
                Ssl =
                {
                    ServerName = hostName,
                    Enabled = false
                }
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: "CONFIRMAR_AULA",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            EventingBasicConsumer consumer = new(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                byte[] contentArray = eventArgs.Body.ToArray();
                string contentString = Encoding.UTF8.GetString(contentArray);
                Aula aula = JsonSerializer.Deserialize<Aula>(contentString);

                ConfirmEvent(aula);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume("CONFIRMAR_AULA", false, consumer);
            return Task.CompletedTask;
        }

        private void ConfirmEvent(Aula aula)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IAulaService aulaService = scope.ServiceProvider.GetRequiredService<IAulaService>();
                aula.AtualizarStatus(StatusAula.Confirmada);
                aulaService.UpdateEvent(aula);
            }
        }
    }
}
