using System;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using rtfm_console_app;

var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")
               ?? throw new InvalidOperationException("Set AZURE_OPENAI_ENDPOINT");

var modelName = Environment.GetEnvironmentVariable("AZURE_OPENAI_MODEL_NAME") ?? "gpt-4o-mini";

AIAgent agent = new AIProjectClient(
        new Uri(endpoint),
        new DefaultAzureCredential()
    )
    .AsAIAgent(
        model: modelName,
        instructions: "You are a friendly helpful assistant answering questions about documentation. " +
                      "Your users are typically developers, software architects or other technically savvy people. " +
                      "You should answer questions about the documentation as concisely as possible, and if you don't know the answer, say you don't know." +
                      "" +
                      "You use tools ",
        name: "DocsAssistant",
        tools: [AIFunctionFactory.Create(Tools.GetDocumentation)]
    );

Console.WriteLine("Ask me anything about the documentation!");
Console.WriteLine(Environment.NewLine);
var question = Console.ReadLine();

Console.WriteLine(await agent.RunAsync());