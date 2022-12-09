using NBomber;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
try
{
await X();

}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
Console.WriteLine("end of story");




async Task X()
{
    
    const string url = $"http://localhost:5000/api/state";
    var step = Step.Create("fetch_html_page",
                                   clientFactory: HttpClientFactory.Create(),
                                   execute: context =>
                                   {
                                       var request = Http.CreateRequest("GET", url)
                                                         .WithHeader("Accept", "text/html");

                                       return Http.Send(request, context);
                                   });

    var scenario = ScenarioBuilder
        .CreateScenario("simple_http", step)
        .WithWarmUpDuration(TimeSpan.FromSeconds(20))
        .WithLoadSimulations(
            Simulation.InjectPerSec(rate: 20, during: TimeSpan.FromSeconds(60))
        );

    // creates ping plugin that brings additional reporting data
    var pingPluginConfig = PingPluginConfig.CreateDefault(new[] { "localhost:5000" });
    var pingPlugin = new PingPlugin(pingPluginConfig);

    NBomberRunner
        .RegisterScenarios(scenario)
        .WithWorkerPlugins(pingPlugin)
        .Run();
}