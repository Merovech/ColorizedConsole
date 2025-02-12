using ColorizedConsole.Configuration;
using ColorizedConsole.Configuration.Classes;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		static ConsoleEx() 
		{
			ApplySettings();
		}

		/// <summary>
		/// The color used for the foreground when calling WriteDebug and WriteDebugLine methods.
		/// </summary>
		public static ConsoleColor DebugColor { get; set; }

		/// <summary>
		/// The color used for the foreground when calling WriteError and WriteWriteLine methods.
		/// </summary>
		public static ConsoleColor ErrorColor { get; set; }

		/// <summary>
		/// The color used for the foreground when calling WriteInfo and WriteInfoLine methods.
		/// </summary>
		public static ConsoleColor InfoColor { get; set; }

		/// <summary>
		/// Applies settings from the environment, config file, or defaults in order of precedence:
		/// 
		/// 1. Settings set on environment variables.
		/// 2. Settings set in cc.config.json.
		/// 3. Defaults.
		/// </summary>
		public static void ApplySettings()
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
