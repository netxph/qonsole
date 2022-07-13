using System.CommandLine;

namespace Qonsole.Core;

public static class TypeActionProviderExtensions
{

    public static AppBuilder AddTypeActions(this AppBuilder builder, params Command[] commands)
    {
		builder.AddActionProvider(
			new TypeActionProvider(commands.ToList()));

		return builder;
    }
}
