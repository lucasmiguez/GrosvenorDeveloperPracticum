using System;
using Application;
using Microsoft.Extensions.DependencyInjection;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMenu, DishManagerMorning>()
                .AddSingleton<IMenuFactory, MenuFactory>()
                .AddSingleton<IServer, Server>()
                .BuildServiceProvider();

            var server = serviceProvider.GetService<IServer>();

            while (true)
            {

                Console.WriteLine("Enter period (morning/evening):");
                var period = Console.ReadLine();

                Console.WriteLine("Enter dishes (comma separated):");
                var dishes = Console.ReadLine();
                
                var output = server.TakeOrder(period.Replace(" ",""), dishes.Replace(" ", ""));
                Console.WriteLine( output);
            }
        }
    }
}
