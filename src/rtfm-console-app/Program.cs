using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using rtfm_console_app;

var endpoint = GetArguments(args, "--endpoint") ?? throw new ArgumentException("endpoint needs to point to azure foundry service");
var modelName = GetArguments(args, "--model") ?? "gpt-4o-mini";

const string instructions =
    """
    You are a friendly helpful assistant answering questions about documentation.
    Your users are typically developers, software architects or other technically savvy people.
    You should answer questions about the documentation as concisely as possible,
    and if you don't know the answer, say you don't know.
    """;

AIAgent agent = new AIProjectClient(
        new Uri(endpoint),
        new DefaultAzureCredential()
    )
    .AsAIAgent(
        model: modelName,
        instructions: instructions,
        name: "DocsAssistant",
        tools: [AIFunctionFactory.Create(Tools.GetDocumentation)]
    );

Console.WriteLine("Ask me anything about the documentation!");
Console.WriteLine(Environment.NewLine);
var question = Console.ReadLine();

Console.WriteLine(await agent.RunAsync());

string? GetArguments(string[] args, string key)
{
    var idx = Array.IndexOf(args, key);
    return idx >= 0 && idx + 1 < args.Length ? args[idx + 1] : null;
}