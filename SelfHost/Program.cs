using Microsoft.Owin.Hosting;
using System;

namespace SacHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WebApp.Start<Startup>("http://localhost:9999"))
            {
                Console.WriteLine("Meu primeiro server host rodando!");
                Console.ReadLine();
            }
        }
    }
}
