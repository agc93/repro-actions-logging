using System;
using Spectre.Console;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Spectre.Console.Extensions.Logging;

namespace logging_actions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World in plain old System.Console-land!");
            AnsiConsole.MarkupLine("[[whatever]] checkout this cool [bold red]formatting[/]");
            var loggerFactory =  LoggerFactory.Create(b => {
                b
                    .AddFilter("logging_actions.Program", LogLevel.Debug)
                    .AddSpectreConsole(config => config.LogLevel = LogLevel.Information);
            });
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Some sample log entry with the [bold underline]full-size[/] logger");
            using (var factory = LoggerFactory.Create(b => b.AddInlineSpectreConsole(c => c.LogLevel = LogLevel.Information))) {
                var iLogger = factory.CreateLogger("SampleCategory");
                iLogger.LogInformation("Some sample log entry with the [bold underline]inline[/] logger");
            }
        }
    }
}
