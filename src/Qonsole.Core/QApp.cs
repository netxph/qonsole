using System.CommandLine;

namespace Qonsole.Core;

public class QApp
{
    public string Description { get; }
    public IEnumerable<IActionProvider> Providers { get; }

	public QApp(IEnumerable<IActionProvider> providers)
		: this(string.Empty, providers)
	{
	}

    public QApp(string description, IEnumerable<IActionProvider> providers)
    {
        Description = description ?? string.Empty;
        Providers = providers ?? new List<IActionProvider>();
    }

    public int Run(string[] args)
    {
        var root = new RootCommand(Description);

        foreach (var provider in Providers)
        {
            var commands = provider.GetCommands();

			foreach (var command in commands)
			{
				root.AddCommand(command);
			}
        }

		return root.InvokeAsync(args).Result;
    }
}
