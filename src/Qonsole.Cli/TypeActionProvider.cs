using System.CommandLine;

namespace Qonsole.Cli;

public class TypeActionProvider : IActionProvider
{
    private readonly IEnumerable<Command> _commands;

    public TypeActionProvider(IEnumerable<Command> commands)
    {
        _commands = commands
            ?? throw new ArgumentNullException(nameof(commands));
    }

    public IEnumerable<Command> GetCommands()
    {
        return _commands;
    }
}
