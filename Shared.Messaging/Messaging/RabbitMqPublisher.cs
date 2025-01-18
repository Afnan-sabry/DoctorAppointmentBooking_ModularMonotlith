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
        private readonly string _hostName = "localhost";
        private readonly string _username = "guest";
        private readonly string _password = "guest";
        private readonly string _virtualHost = "/";      // RabbitMQ virtual host

        public async Task PublishMessageAsync<T>(string queueName, T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _username,
                Password = _password,
                VirtualHost = _virtualHost
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // Declare a queue (it will be created if it doesn't exist)
            await channel.QueueDeclareAsync(queue: queueName,
                                   durable: false,  // Queue will not survive server restarts
                                   exclusive: false, // Queue is not exclusive to this connection
                                   autoDelete: false, // Queue won't be deleted when not in use
                                   arguments: null);

            // Serialize message to JSON
            var messageBody = System.Text.Json.JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageBody);

            // Publish the message to the default exchange with the routing key as the queue name
            await channel.BasicPublishAsync(exchange: "",
                                  routingKey: queueName,  // Queue name as the routing key
                                  body: body);

            Console.WriteLine($"Message sent: {messageBody}");
        }
        //public async Task PublishMessageAsync<T>(T message, string queueName)
        //{

        //    var factory = new ConnectionFactory { HostName = _hostName, UserName = _username, Password = _password };


        //    using var connection =await factory.CreateConnectionAsync();
        //    using var channel =await connection.CreateChannelAsync();

        //    // await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        //    channel.BasicReturnAsync +=async (sender, ea) =>
        //    {
        //        Console.WriteLine($"BasicReturn==> {ea.ReplyText} ");
        //        Console.WriteLine("=============================================================");

        //    };

        //    channel.BasicAcksAsync +=async (sender, ea) =>
        //    {
        //        Console.WriteLine($"BasicAcks==> {ea.DeliveryTag} ");
        //        Console.WriteLine("=============================================================");

        //    };


        //    var messageJson = JsonConvert.SerializeObject(message);
        //    var body = Encoding.UTF8.GetBytes(messageJson);

        //    await  channel.BasicPublishAsync(exchange: "", routingKey: queueName, body: body);
        //}
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
