using System.CommandLine;

namespace Qonsole.Core;

public class ProcessActionProvider : IActionProvider
{
    private readonly string _prefix;

    public ProcessActionProvider(string prefix)
    {
        if(string.IsNullOrEmpty(prefix))
        {
            throw new ArgumentNullException(nameof(prefix));
        }

        _prefix = prefix;
    }

    public IEnumerable<Command> GetCommands()
    {
        return new List<Command>();
    }
}
