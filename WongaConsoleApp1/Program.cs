using RabbitMQ.Client;
using System;
using System.Text;

namespace WongaConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            var msg = "Hello my name is, " + name;

            var response = Messaging.PublishMessage(msg, "name");

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
