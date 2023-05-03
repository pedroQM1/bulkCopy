


using ImportManager.Orchestrator;
using Microsoft.Extensions.Logging;
using System;
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

var cancelationSourceToken = new CancellationTokenSource();
var cancelationToke = cancelationSourceToken.Token;


Console.CancelKeyPress += (ob, args) =>
{
    args.Cancel = true;
    cancelationSourceToken.Cancel();
    Console.WriteLine("Processo de importação cancelado");
};
Console.WriteLine("Pressione CTRL+C para cancelar...");

var orchestrador = importOrchestrator.Create(loggerFactory);
await orchestrador.Handler(args[0], cancelationToke);

timer.Stop();
TimeSpan timeTaken = timer.Elapsed;
Console.WriteLine($"Importação finalizada com sucesso tempo : {timeTaken.ToString(@"m\:ss\.fff")}");
Console.ReadLine();




