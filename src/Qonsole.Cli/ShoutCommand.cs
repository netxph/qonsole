using System.CommandLine;

namespace Qonsole.Cli;

public class ShoutCommand : Command
{
    public ShoutCommand() : base("shout", "Shouts at console")
    {
    }
}

