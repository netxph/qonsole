using System.CommandLine;

namespace Qonsole.Cli;

public class AppBuilder
{

    public QApp Build()
    {
        throw new NotImplementedException();
    }

    public QApp AddTypeActions(params Command[] commands)
    {
        throw new NotImplementedException();
    }

    public static implicit operator QApp(AppBuilder obj)
    {
        return obj.Build();
    }
}
