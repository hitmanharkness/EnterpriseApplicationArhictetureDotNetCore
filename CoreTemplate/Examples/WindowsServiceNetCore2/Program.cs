using System;
using System.Collections.Generic;
using BI.Aspect.RabbitMq.Core;
using BI.QueueConsumer.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WindowsServiceNetCore2
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static ILogger<Program> Logger { get; set; }
        public static AppSettings AppSettings { get; set; } 

        static void Main(string[] args)
        {
            // Setup our DI.
            var serviceProvider = new ServiceCollection();
            // Configure our services.
            ConfigureServices(serviceProvider);

            Logger.LogDebug("Starting application.");

            // Testing the Aspect.Consumer.
            var service = new ServiceConsumer(AppSettings.rabbitMQSettings);
            service.StartService();

            Console.WriteLine("Service Consumer Started.");

            Console.WriteLine("Press ESC to stop");
            do
            {
                //while (!Console.KeyAvailable)
                //{
                //}
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1&tabs=basicconfiguration
        public static void ConfigureServices(IServiceCollection services)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                //.AddSingleton<IFooService, FooService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);


            // Defines the sources of configuration information for the application.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("the-key", "the-value"),
                });

            // Create the configuration object that the application will
            // use to retrieve configuration information.
            Configuration = builder.Build();

            // grab the logger.
            Logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            AppSettings = Configuration.GetSection("App").Get<AppSettings>();

            //services.Configure<AppSettings>(Configuration.GetSection("mysettings"));

        }
    }

    public class AppSettings
    {
        public AppSettings()
        {
    
        }
        public RabbitMqSettingsValues rabbitMQSettings { get; set; }
        //public RabbitMQSettings rabbitMQSettings { get; set; }
    }

    //public class RabbitMQSettings
    //{
    //    public string RabbitMQHost { get; set; }
    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public string ExchangeName { get; set; }
    //    public string QueueName { get; set; }
    //    public string NoAck { get; set; }
    //    public string MaxChannels { get; set; }

    //}
}
