using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace MessageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:59093/message";
            var serverConnect = new HubConnectionBuilder()
                 .WithUrl(new Uri(url)).WithAutomaticReconnect().Build();
            serverConnect.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Not Connected");
                }
                else
                {
                    Console.WriteLine("Connected");

                    serverConnect.On<string>("BroadcastMessage", (message) =>
                    {
                        Console.WriteLine(message);
                    });

                    Console.ReadKey();
                }
            }).Wait();
        }
    }
}
