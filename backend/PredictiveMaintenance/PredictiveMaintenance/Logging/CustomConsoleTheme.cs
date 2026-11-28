using Serilog.Sinks.SystemConsole.Themes;

namespace PredictiveMaintenance.Logging;

public static class CustomConsoleTheme
{
    public static AnsiConsoleTheme Theme { get; } =
        new(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[37m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[90m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[90m",
                [ConsoleThemeStyle.Invalid] = "\u001b[31m",
                [ConsoleThemeStyle.Null] = "\u001b[36m",
                [ConsoleThemeStyle.Name] = "\u001b[36m",
                [ConsoleThemeStyle.String] = "\u001b[32m",
                [ConsoleThemeStyle.Number] = "\u001b[35m",
                [ConsoleThemeStyle.Boolean] = "\u001b[35m",
                [ConsoleThemeStyle.Scalar] = "\u001b[37m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[90m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[36m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[34m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[33m",
                [ConsoleThemeStyle.LevelError] = "\u001b[31m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[41;97m"
            });
}
