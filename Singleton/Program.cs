using System;
using System.Collections.Generic;
using static System.Console;
namespace Singleton.NetOptimized
{
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public sealed class LoadBalancer
    {
        //сутність
        private static readonly LoadBalancer instance = new LoadBalancer();
        //cписок серверів
        private readonly List<Server> servers;

        // Уважно: конструктор - private
        private LoadBalancer()
        {
            // Створюємо список серверів
            servers = new List<Server>
                {
                  new Server{ Name = "ServerI", IP = "120.14.220.18" },
                  new Server{ Name = "ServerII", IP = "120.14.220.19" },
                  new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                  new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                  new Server{ Name = "ServerV", IP = "120.14.220.22" },
                };
        }
        public static LoadBalancer GetLoadBalancer() //дістаємо сутність
        {
            return instance;
        }

        // Створюємо примітивний LoadBalancer через рандом

        private readonly Random random = new Random();
        public Server NextServer
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r];
            }
        }
    }
    /// <summary>
    /// Репрезентація сервера
    /// </summary>
    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }

    public class Program
    {
        /// <summary>
        /// Singleton Design Pattern
        /// </summary>
        public static void Main()
        {
            // Здійснюємо 15 load balance запитів до сервера
            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                WriteLine("Dispatch request to: " + serverName);
            }
            // Чекаємо
            ReadKey();
        }
    }
}
