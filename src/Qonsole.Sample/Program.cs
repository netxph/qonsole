using System.CommandLine;

// See https://aka.ms/new-console-template for more information

var root = new RootCommand("Hello world sample application");

root.Add(
    new Option<string>(
        aliases: new string[] { "--name", "-n" },
        description: "Name to greet"
    ));

root.SetHandler((name) =>
    Console.WriteLine($"Hello, {name}!!!")
);

await root.InvokeAsync(args);
