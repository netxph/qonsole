namespace Qonsole.Cli;

public class AppBuilder
{
    private readonly List<IActionProvider> _providers;
	private string _description;

    public AppBuilder()
    {
        _providers = new List<IActionProvider>();
		_description = string.Empty;
    }

    public QApp Build()
    {
        var app = new QApp(_description, _providers);

        return app;
    }

    public void AddActionProvider(IActionProvider provider)
    {
        if (provider == null)
        {
            throw new ArgumentNullException(nameof(provider));
        }

        _providers.Add(provider);
    }

    public AppBuilder Describe(string description)
    {
		_description = description ?? string.Empty;

		return this;
    }

    public static implicit operator QApp(AppBuilder obj)
    {
        return obj.Build();
    }
}
