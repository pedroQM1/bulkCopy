


using ImportManager.Orchestrator;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

var loggerFactory = LoggerFactory.Create(
           builder => builder
                       // add console as logging target
                       .AddConsole()
                       // add debug output as logging target
                       .AddDebug()
                       // set minimum level to log
                       .SetMinimumLevel(LogLevel.Debug)
       );


var timer = new Stopwatch();
timer.Start();

var orchestrador = importOrchestrator.Create(loggerFactory);
orchestrador.Handler(args[0]);

timer.Stop();
TimeSpan timeTaken = timer.Elapsed;
Console.WriteLine($"Importação finalizada com sucesso tempo : {timeTaken.ToString(@"m\:ss\.fff")}");
Console.ReadLine();




