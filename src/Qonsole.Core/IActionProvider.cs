using System.CommandLine;

namespace Qonsole.Core;

public interface IActionProvider
{
    IEnumerable<Command> GetCommands();
}
