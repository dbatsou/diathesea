using System.Text;
using System.Text.Json;
using NBomber.Contracts;
using NBomber.Contracts.Stats;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string baseUrl = "http://localhost:5000/api";
string GObaseUrl = "http://localhost:8080";
try
{
    CreateScenarios();

}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
Console.WriteLine("end of story");




void CreateScenarios()
{
    var httpFactory = ClientFactory.Create(
        name: "http_factory",
        clientCount: 5,
        initClient: (number, context) => Task.FromResult(new HttpClient())
    );
    var stateEntryBody = JsonSerializer.Serialize(new { StateId = 1, Date = DateTime.Now, Note = "welcome to the jungle" });

    var steps = new[]
    {
        CreateStep(httpFactory,"getStates", "/state", HttpMethod.Get),
		//CreateStep(httpFactory,"getEntries", "/stateEntry", HttpMethod.Get),
		//CreateStep(httpFactory,"addStateEntry", "/stateEntry", HttpMethod.Post,stateEntryBody),
	};

    var scenario = ScenarioBuilder
        .CreateScenario("addEntry", steps)
        .WithWarmUpDuration(TimeSpan.FromSeconds(0))
        .WithLoadSimulations(
            Simulation.KeepConstant(500, during: TimeSpan.FromSeconds(300))
        );

    // creates ping plugin that brings additional reporting data
    var pingPluginConfig = PingPluginConfig.CreateDefault(new[] { "localhost" });
    var pingPlugin = new PingPlugin(pingPluginConfig);

    NBomberRunner
        .RegisterScenarios(scenario)
        .WithWorkerPlugins(pingPlugin)
        .WithReportFormats(ReportFormat.Html)
        .Run();
}

IStep CreateStep(IClientFactory<HttpClient> clientFactory, string name, string url, HttpMethod method, string body = null)
{
    baseUrl = GObaseUrl;
    string uri = $"{baseUrl}{url}";
    var step = Step.Create(name,
        clientFactory: clientFactory,
        execute: context =>
        {
            var request = Http.CreateRequest(method.Method, uri);

            if (!string.IsNullOrEmpty((body)))
            {
                var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                request = request.WithBody(stringContent);
            }
            var resp = Http.Send(request, context);
            return resp;
        });
    return step;
}