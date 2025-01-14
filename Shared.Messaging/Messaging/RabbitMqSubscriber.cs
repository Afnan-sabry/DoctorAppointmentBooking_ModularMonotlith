using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;


namespace Shared.Messaging.Messaging
{
    public class RabbitMqSubscriber
    {
        private readonly string _hostName = "DoctorAppointmentBooking";
        public async Task Subscribe<T>( string queue,  Action<T> onMessageReceived)
        {
            string exchange = "";
            string routingKey=queue;
            var factory = new ConnectionFactory { HostName = _hostName };

            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            // Declare exchange and queue
            await channel.ExchangeDeclareAsync(exchange: exchange, type: "topic");
            await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            await channel.QueueBindAsync(queue: queue, exchange: exchange, routingKey: routingKey);

            // Set up consumer
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<T>(body);
                onMessageReceived(message);
            };

            // Start consuming
            await channel.BasicConsumeAsync(queue: queue, autoAck: true, consumer: consumer);

            Console.WriteLine($"Subscribed to {exchange} with queue {queue} and routing key {routingKey}");
        }

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
    }
}
