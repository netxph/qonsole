using System.CommandLine;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Qonsole.Cli;

public class HostedCommand : Command
{
    public HostedCommand()
        : base("hosted", "Hosted command demo")
    {
        var sourceOption = new Option<string>(
            aliases: new string[] { "--source", "-s" },
            description: "Source file");

        this.AddOption(sourceOption);

        var nameOption = new Option<string>(
            aliases: new string[] { "--name", "-n" },
            description: "Name of action to be loaded");

        this.AddOption(nameOption);

        var targetOption = new Option<string>(
            aliases: new string[] { "--target", "-t" },
            description: "The target extra parameter");

        this.AddOption(targetOption);

        this.SetHandler(async (source, name, target) =>
            await ExecuteAsync(source, name, target),
            sourceOption, nameOption, targetOption);
    }

    public async Task ExecuteAsync(string source, string name, string target)
    {
        var assembly = Assembly.LoadFrom(source);
		var type = assembly.GetTypes().FirstOrDefault(t => t.Name == name);

        //rehydrate args
        string[] args = { $"target={target}" };

        IHost host = Host.CreateDefaultBuilder(args)
			.ConfigureServices((hostContext, services) =>
			{
				if(type != null)
				{
					services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IHostedService), type));
				}
			})
            .Build();

        await host.RunAsync();
    }
}
