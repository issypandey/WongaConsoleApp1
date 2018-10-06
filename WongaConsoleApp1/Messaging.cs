using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace WongaConsoleApp1
{
    public class Messaging
    {
        public static string PublishMessage(string message, string routeKey)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                try
                {
                    if(message == null || message == "")
                    {
                        return "No Message Passed";
                    }
                    else if(routeKey == null || routeKey == "")
                    {
                        return "Route Key is null";
                    }
                    channel.QueueDeclare(queue: "name",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "name",
                                         basicProperties: null,
                                         body: Encoding.UTF8.GetBytes(message));
                    return "Y";
                }
                catch(Exception e)
                {
                    return e.Message;
                }               
                
            }
            
        }

        public static string PublishMessage(string message, string routeKey, string hostName)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "name",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.BasicPublish(exchange: "",
                                     routingKey: "name",
                                     basicProperties: null,
                                     body: Encoding.UTF8.GetBytes(message));
            }
            return "Y";
        }
    }
}
