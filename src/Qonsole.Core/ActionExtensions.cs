using System.CommandLine;
using System.Reflection;

namespace Qonsole.Core;

public static class TypeActionProviderExtensions
{

    public static AppBuilder AddTypeActions(this AppBuilder builder, params Command[] commands)
    {
		builder.AddActionProvider(
			new TypeActionProvider(commands.ToList()));

		return builder;
    }

    public static AppBuilder AddExecutableActions(this AppBuilder builder)
    {
        var prefix = Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;

        return AddExecutableActions(builder, prefix);
    }

    public static AppBuilder AddExecutableActions(this AppBuilder builder, string prefix)
    {

        return builder;
    }
}
