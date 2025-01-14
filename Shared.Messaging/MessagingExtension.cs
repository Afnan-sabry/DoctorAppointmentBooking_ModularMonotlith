using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Shared.Messaging.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messaging
{
    public static class MessagingExtension
    {
        public static IServiceCollection AddMessagingExtension(this IServiceCollection services, IConfiguration config) {
            //services.AddScoped(typeof(IRabbitMQPublisher<>), typeof(RabbitMqPublisher<>));
            //services.AddScoped(typeof(IRabbitMqSubscriber<>), typeof(RabbitMqSubscriber<>));

            return services;
        }

    }
}
