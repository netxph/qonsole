﻿using Qonsole.Cli;
using Qonsole.Core;

QApp app = new AppBuilder()
    .Describe("Qonsole Demo Cli")
    .AddTypeActions(
        new ShoutCommand(),
        new GreetCommand(),
        new HostedCommand())
    .AddExecutableActions();

return await app.RunAsync(args);
