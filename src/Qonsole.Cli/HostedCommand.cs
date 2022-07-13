using System.CommandLine;

namespace Qonsole.Cli;

public class HostedCommand : Command
{
    public HostedCommand()
        : base("hosted", "Hosted command demo")
    {
    }
}
