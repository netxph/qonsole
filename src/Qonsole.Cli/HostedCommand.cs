using System.CommandLine;

namespace Qonsole.Cli;

public class HostedCommand : Command
{
    public HostedCommand()
        : base("hosted", "Hosted command demo")
    {
		var sourceOption = new Option<string>(
			name: "--source",
			description: "Source file");

		this.AddOption(sourceOption);

		var nameOption = new Option<string>(
			name: "--name",
			description: "Name of action to be loaded");

		this.AddOption(nameOption);

		this.SetHandler(async (source, name) =>
			await ExecuteAsync(source, name),
			sourceOption, nameOption);
    }

	public async Task ExecuteAsync(string source, string name)
	{
		await Console.Out.WriteLineAsync(source);
		await Console.Out.WriteLineAsync(name);
	}
}
