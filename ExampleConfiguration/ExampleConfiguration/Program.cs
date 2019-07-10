using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace ExampleConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsetting.json", true, true).Build();
            Console.WriteLine($"Hello World, { config["name"] }!");
        }
    }
}
