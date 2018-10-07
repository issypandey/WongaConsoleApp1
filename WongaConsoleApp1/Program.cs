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
            var name = "";
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            while (name != "exit")
            {                
                var msg = "Hello my name is, " + name;
                var response = Messaging.PublishMessage(msg, "name");
                Console.WriteLine("Type 'exit' to exit or re-enter a name.");
                name = Console.ReadLine();
            }
        }
    }
}
