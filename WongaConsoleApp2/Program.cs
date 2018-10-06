using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace WongaConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "name",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var name = message.Substring(18);
                    if (name != null && name != "")
                    {
                        Console.WriteLine("Hello {0}, I am your father", name);
                    }
                    else
                    {
                        Console.WriteLine("Invalid name passed.");
                    }
                };
                channel.BasicConsume(queue: "name",
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}
