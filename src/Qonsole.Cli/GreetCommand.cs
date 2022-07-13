using System.CommandLine;

namespace Qonsole.Cli;

public class GreetCommand : Command
{
    public GreetCommand() : base("greet", "Greets at console")
    {
    }
}
