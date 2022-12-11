using System.Text;
using System.Text.Json;
using Domain.Entities;
using NBomber.Contracts;
using NBomber.Contracts.Stats;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
try
{
	BombIt();

}
catch (Exception e)
{
	Console.WriteLine(e);
	throw;
}
Console.WriteLine("end of story");




void BombIt()
{
	var client = HttpClientFactory.Create();
	var entry = new StateEntry() {StateId = 1, Date = DateTime.Now, Note = "welcome to the jungle"};
	var stateEntryBody = JsonSerializer.Serialize(entry);
	
	var steps = new[]
	{
		CreateStep(client,"getStates", "/state", HttpMethod.Get),
		CreateStep(client,"getEntries", "/stateEntry", HttpMethod.Get),
		// CreateStep(client,"addStateEntry", "/stateEntry", HttpMethod.Post,stateEntryBody),
	};
	
	var scenario = ScenarioBuilder
		.CreateScenario("addEntry", steps)
		.WithWarmUpDuration(TimeSpan.FromSeconds(30))
		.WithLoadSimulations(
			Simulation.KeepConstant(200, during: TimeSpan.FromSeconds(600))
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

IStep CreateStep(IClientFactory<HttpClient> clientFactory, string name, string url, HttpMethod method, string body=null)
{
	string uri = $"http://localhost:5000/api{url}";
	var step = Step.Create(name,
		clientFactory: clientFactory,
		execute: context =>
		{
			var request = Http.CreateRequest(method.Method, uri).WithHeader("Content-Type", "application/json");
			
			if (!string.IsNullOrEmpty((body)))
			{
				var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
				request = request.WithBody(stringContent);
			}
			var resp=  Http.Send(request, context);
			return resp;
		});
	return step;
}