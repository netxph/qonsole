using System.CommandLine;
using System.Reflection;

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
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        Console.WriteLine(path);

        var pattern = $"{_prefix}*.exe";
        Console.WriteLine(pattern);

        var files = Directory.GetFiles(path, pattern);

        files.ToList().ForEach(f => Console.WriteLine(f));

        return new List<Command>();
    }
}
