using System.CommandLine;
using System.Diagnostics;
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
        var pattern = $"{_prefix}*.exe";

        var files = Directory.GetFiles(path, pattern);

        return files.ToList().Select(f => {
            var name = Path.GetFileNameWithoutExtension(f).Split("-")[1];

            var info = FileVersionInfo.GetVersionInfo(f);

            return new Command(name, info.FileDescription);
        }).ToList();
    }
}
