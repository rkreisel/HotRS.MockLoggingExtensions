using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
