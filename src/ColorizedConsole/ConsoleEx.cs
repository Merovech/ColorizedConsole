using ColorizedConsole.Configuration;
using ColorizedConsole.Configuration.Classes;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		public static ConsoleColor DebugColor { get; set; }

		public static ConsoleColor ErrorColor { get; set; }

		public static ConsoleColor InfoColor { get; set; }

		public static void ApplySettings(string? filename)
		{
            // Order of precedence:
            // * Environment
            // * Existing file
            // * Defaults (written to file if none exist)

			// Environment
            if (Settings.TryGetFromEnvironment(out Settings settings))
            {
				SetColorsFromSettings(settings);
				return;
            }

			if (File.Exists(Settings.ConfigFileName) && Settings.TryGetFromFile(out settings))
			{
				SetColorsFromSettings(settings);
			}
			else
			{
				// If no settings exist, write a default set and use that
				Settings defaultSettings = new();
				defaultSettings.WriteToFile();
				SetColorsFromSettings(defaultSettings);
			}
		}

		// This was the only way I could think to avoid writing the same four lines a million times.
		// I'm open to better options.
		internal static void WriteColorized(ConsoleColor color, Action writeAction)
		{
			var tmp = Console.ForegroundColor;
			ForegroundColor = color;
			writeAction();
			Console.ForegroundColor = tmp;
		}

		private static void SetColorsFromSettings(Settings settings)
		{
			DebugColor = settings.Colors.DebugColor;
			ErrorColor = settings.Colors.ErrorColor;
			InfoColor = settings.Colors.InfoColor;			
		}
	}
}
