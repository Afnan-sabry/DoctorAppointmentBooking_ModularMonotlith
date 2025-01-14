using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Messaging.Messaging
{
    public class RabbitMqPublisher
    {
        private readonly string _hostName = "DoctorAppointmentBooking";
        public async Task PublishMessageAsync<T>(T message, string queueName)
        {

            var factory = new ConnectionFactory
            {
                HostName = _hostName,
            };

            using var connection =await factory.CreateConnectionAsync();
            using var channel =await connection.CreateChannelAsync();
           await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var messageJson = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageJson);

            await  channel.BasicPublishAsync(exchange: "", routingKey: queueName, body: body);
        }
        #region comment
        //public async Task Publish<T>(T message, string exchange, string routingKey)
        //{
        //    var factory = new ConnectionFactory { HostName = _hostName };

        //    using var connection =await factory.CreateConnectionAsync();
        //    using var channel =await connection.CreateChannelAsync();

        //    // Declare exchange
        //   await channel.ExchangeDeclareAsync(exchange: exchange, type: "topic");

        //    // Serialize message
        //    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        //    // Publish message
        //    await channel.BasicPublishAsync(
        //        exchange: exchange,
        //        routingKey: routingKey,
        //        body: body,
        //        mandatory:true);

        //    Console.WriteLine($"Message published to {exchange} with routing key {routingKey}");
        //}
        #endregion

    }
}
