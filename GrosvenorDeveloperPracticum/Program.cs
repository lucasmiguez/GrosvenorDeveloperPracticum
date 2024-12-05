using System;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main()
        {
            /*
             * * Incorporate Dependency Injection(DI)
             * * Singleton Pattern 
             */
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMenu, DishManagerMorning>()
                .AddSingleton<IMenuFactory, MenuFactory>() 
                .AddSingleton<IServer, Server>()
            .BuildServiceProvider();

            //Inversion of Control(IoC)
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
