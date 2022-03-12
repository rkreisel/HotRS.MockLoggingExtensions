using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using TestApp;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
        .AddConsole();
});
ILogger logger = loggerFactory.CreateLogger<Program>();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<LoggingTester>();
    });
var app = host.Build();
ILoggingTester loggingTester = app.Services.GetRequiredService<LoggingTester>();
loggingTester.LogError("Info");
Console.WriteLine("Press any key to exit");
Console.ReadKey();

#region Dummy class to allow us to exclude program.cs from code coverage
#pragma warning disable CA1050 // Declare types in namespaces
[ExcludeFromCodeCoverage]
public partial class Program
{

}
#pragma warning restore CA1050 // Declare types in namespaces
#endregion