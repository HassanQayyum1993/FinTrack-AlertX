using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using System.Text;

namespace FinTrack.AlertX.Services
{

    public class MessageQueueService
    {
        private readonly ConnectionFactory _factory;

        public MessageQueueService()
        {
            _factory = new ConnectionFactory() { HostName = "rabbitmq" };
        }

        public async Task SendEmailNotification(int userId, string message)
        {
            SendMessage("email_queue", userId, message);
        }

        public async Task SendSmsNotification(int userId, string message)
        {
            SendMessage("sms_queue", userId, message);
        }

        private void SendMessage(string queueName, int userId, string message)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes($"{userId}:{message}");
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }

}
