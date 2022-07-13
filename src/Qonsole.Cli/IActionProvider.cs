using System.CommandLine;

namespace Qonsole.Cli;

public interface IActionProvider
{
    IEnumerable<Command> GetCommands();
}
