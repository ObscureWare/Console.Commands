﻿namespace ConsoleTests
{
    using System.Globalization;

    using ObscureWare.Console.Commands;
    using ObscureWare.Console.Commands.Styles;

    using ObscureWare.Console;

    public class TestCommands
    {
        public TestCommands(IConsole console)
        {
            ConsoleContext context = new ConsoleContext();
            var options = new CommandParserOptions
                {
                    UiCulture = CultureInfo.CreateSpecificCulture("en-US"), // "pl-PL"
                    FlagCharacters = new[] {@"\", "-"},
                    SwitchCharacters = new[] {@"-", "--"},
                    OptionArgumentMode = CommandOptionArgumentMode.Separated,
                    OptionArgumentJoinCharacater = ':', // not used because of: CommandOptionArgumentMode.Separated
                    AllowFlagsAsOneArgument = false,
                    CommandsSensitivenes = CommandCaseSensitivenes.Insensitive,
                    SwitchlessOptionsMode = SwitchlessOptionsMode.EndOnly, // TODO: let the command decide ?
                };

            var engine =
                CommandEngineBuilder.Build()
                    //.WithCommands(typeof(DirCommand), typeof(ClsCommand), typeof(ExitCommand), typeof(ChangeDirUpCommand), typeof(ChangeDirCommand))
                    .WithCommandsFromAssembly(this.GetType().Assembly)
                    .UsingOptions(options)
                    .UsingStyles(CommandEngineStyles.DefaultStyles)
                    .ConstructForConsole(console);


            //engine.Styles = new CommandEngineStyles
            //{
            //    // custom styles go here
            //};

            bool executedProperly = engine.ExecuteCommand(context, @"dir \d -m CurrentDir -f *.*");
            //engine.ExecuteCommand(context, console, "cls" );
            engine.ExecuteCommand(context, @"diraa");
            engine.ExecuteCommand(context, @"-help");
            engine.ExecuteCommand(context, @"dir -h");


            // now manual testing ;-)
            engine.Run(context);
        }
    }
}
