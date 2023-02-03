using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

// See https://aka.ms/new-console-template for more information

var root = new RootCommand("Hello world sample application");

var nameOption = 
    new Option<string>(
        aliases: new string[] { "--name", "-n" },
        description: "Name to greet"
    );

root.Add(nameOption);

root.SetHandler((name) =>
    Console.WriteLine($"Hello, {name}!!!"),
    nameOption
);

var help = new Command("output-help", "")
{
    IsHidden = true
};

root.AddCommand(help);

var builder = new CommandLineBuilder(root);

builder.UseDefaults();

var parser = builder.Build();

Console.WriteLine(string.Join(" ", args));

await parser.InvokeAsync(args);
