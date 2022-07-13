using Qonsole.Cli;

Console.WriteLine("Qonsole Demo Cli");

QApp app = new AppBuilder()
    .AddTypeActions(
        new ShoutCommand(),
        new GreetCommand());

app.Run();
