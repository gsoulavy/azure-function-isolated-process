using System.Diagnostics;

using Function.IsolatedProcess.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

{
    // #if DEBUG
    Debugger.Launch();

    // #endif
}

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(
        s => { s.AddSingleton<IHttpResponderService, DefaultHttpResponderService>(); }
    )
    .Build();

await host.RunAsync();
