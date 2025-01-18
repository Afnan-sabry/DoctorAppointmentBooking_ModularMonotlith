using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;


namespace Shared.Messaging.Messaging
{
    public class RabbitMqSubscriber
    {
        private readonly string _hostName = "localhost";
        private readonly string _username = "guest";
        private readonly string _password = "guest";
        private readonly string _virtualHost = "/";      // RabbitMQ virtual host

     
        public async Task Subscribe<T>(string queueName, Action<T> onMessageReceived)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _username,
                Password = _password,
                VirtualHost = _virtualHost
            };

            using var connection =await factory.CreateConnectionAsync();
            using var channel =await connection.CreateChannelAsync();

            // Declare the same queue as the publisher
           await channel.QueueDeclareAsync(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            //consumer.ReceivedAsync +=async (model, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var messageJson = Encoding.UTF8.GetString(body);

            //    // Deserialize message to the expected object
            //    var message = JsonSerializer.Deserialize<dynamic>(messageJson);

            //    // Process the message
            //    Console.WriteLine($"Received message: AppointmentId = {message.AppointmentId}, Slot = {message.Slot}");
            //};
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<T>(body);
                onMessageReceived(message);
            };

            // Start consuming messages from the queue
            await channel.BasicConsumeAsync(queue: queueName,
                                 autoAck: true,  // Auto-acknowledge the message (or implement manual ack)
                                 consumer: consumer);

            Console.WriteLine($"Waiting for messages from queue '{queueName}'...");
            Console.ReadLine();  // Keep the consumer running
        }
    }


}

    //public async Task Subscribe<T>(string queue, Action<T> onMessageReceived)
    //{
    //    try
    //    {

    //    string exchange = "amq.topic";
    //    string routingKey = queue;
    //    var factory = new ConnectionFactory { HostName = _hostName, UserName = _username, Password = _password };

    //    var connection = await factory.CreateConnectionAsync();
    //    var channel = await connection.CreateChannelAsync();

    //    //// Declare exchange and queue
    //    //await channel.ExchangeDeclareAsync(exchange: exchange, type: "topic");
    //    //await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    //    //await channel.QueueBindAsync(queue: queue, exchange: exchange, routingKey: routingKey);

    //    // Set up consumer
    //    var consumer = new AsyncEventingBasicConsumer(channel);
    //    consumer.ReceivedAsync += async (model, ea) =>
    //    {
    //        var body = ea.Body.ToArray();
    //        var message = JsonSerializer.Deserialize<T>(body);
    //        onMessageReceived(message);
    //    };

    //    // Start consuming
    //    await channel.BasicConsumeAsync(queue: queue, autoAck: true, consumer: consumer);

    //    Console.WriteLine($"Subscribed to {exchange} with queue {queue} and routing key {routingKey}");
    //}
    //    catch (Exception ex)
    //    {

    //        throw;
    //    }

    //}

    #region comment
    //public async Task Subscribe<T>(string exchange, string queue, string routingKey, Action<T> onMessageReceived)
    //{
    //    var factory = new ConnectionFactory { HostName = _hostName };

    //    var connection = await factory.CreateConnectionAsync();
    //    var channel = await connection.CreateChannelAsync();

    //    // Declare exchange and queue
    //    await channel.ExchangeDeclareAsync(exchange: exchange, type: "topic");
    //    await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    //    await channel.QueueBindAsync(queue: queue, exchange: exchange, routingKey: routingKey);

    //    // Set up consumer
    //    var consumer = new AsyncEventingBasicConsumer(channel);
    //    consumer.ReceivedAsync += async (model, ea) =>
    //    {
    //        var body = ea.Body.ToArray();
    //        var message = JsonSerializer.Deserialize<T>(body);
    //         onMessageReceived(message);
    //    };

    //    // Start consuming
    //    await channel.BasicConsumeAsync(queue: queue, autoAck: true, consumer: consumer);

    //    Console.WriteLine($"Subscribed to {exchange} with queue {queue} and routing key {routingKey}");
    //}
    #endregion

