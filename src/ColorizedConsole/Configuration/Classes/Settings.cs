using System.Runtime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ColorizedConsole.Configuration
{
	public class Settings
	{
		[JsonPropertyName("colors")]
		public ColorSettings Colors { get; set; }

		/// <summary>
		/// Initializes a new instance of the Settings class with default values.
		/// </summary>
		public Settings()
		{
			// Use defaults
			Colors = new();
		}

		/// <summary>
		/// Initializes a new instance of the Settings class with customized values.
		/// </summary>
		/// <param name="debugColor">The color for the Debug methods.  If null, uses the default.</param>
		/// <param name="errorColor">The color for the Error methods.  If null, uses the default.</param>
		/// <param name="consoleColor">The color for the Info methods.  If null, uses the default.</param>
		public Settings(ConsoleColor? debugColor, ConsoleColor? errorColor, ConsoleColor? consoleColor) : this()
		{
			Colors.DebugColor = debugColor ?? Constants.DebugColor;
			Colors.ErrorColor = errorColor ?? Constants.ErrorColor;
			Colors.InfoColor = consoleColor ?? Constants.InfoColor;
		}

		public static Settings Default { get; set; } = new Settings();

		public static string ConfigFileName { get => "cc.config.json"; }

		/// <summary>
		/// Attempts to get an instance of the Settings class from the config file.
		/// </summary>
		/// <param name="settings">An out parameter representing the Settings instance.</param>
		/// <returns>True if the file exists and can be successfully parsed; otherwise false.</returns>
		/// <remarks>The config file is cc.config.json.</remarks>
		public static bool TryGetFromFile(out Settings settings)
		{
			settings = new();
			try
			{
				if (!File.Exists(ConfigFileName))
				{
					return false;
				}

				using FileStream fileStream = File.OpenRead(ConfigFileName);
				Settings? parsedSettings = JsonSerializer.Deserialize<Settings>(fileStream);

				if (parsedSettings == null)
				{
					// No valid JSON
					return false;
				}

				settings.Colors.DebugColor = parsedSettings.Colors.DebugColor;
				settings.Colors.ErrorColor = parsedSettings.Colors.ErrorColor;
				settings.Colors.InfoColor = parsedSettings.Colors.InfoColor;

				return true;
			}
			catch (Exception)
			{
				// This could happen in the ConsoleEx constructor, so use Console here instead so the user has at least some idea
				// that something happened.
				Console.WriteLine("Unable to parse cc.config.json due to a parse error.");

				// Do nothing
				return false;
			}
		}

		/// <summary>
		/// Attempts to get an instance of the Settings class from environment variables.
		/// </summary>
		/// <param name="settings">An out parameter representing the Settings instance.</param>
		/// <returns>True if one or more variables exists and can be successfully parsed; otherwise false.</returns>
		public static bool TryGetFromEnvironment(out Settings settings)
		{
			settings = new();

			// If none of the vars exist, return false.  Otherwise, go ahead and set what we can.
			// If any fail to parse, skip it.
			var debugStr = System.Environment.GetEnvironmentVariable(Constants.DebugEnvironmentVarName);
			var errorStr = System.Environment.GetEnvironmentVariable(Constants.ErrorEnvironmentVarName);
			var infoStr = System.Environment.GetEnvironmentVariable(Constants.InfoEnvironmentVarName);

			if (debugStr == null && errorStr == null && infoStr == null)
			{
				return false;
			}

			settings.Colors.DebugColor = Enum.TryParse(debugStr, out ConsoleColor color) ? color : Constants.DebugColor;
			settings.Colors.ErrorColor = Enum.TryParse(errorStr, out color) ? color : Constants.DebugColor;
			settings.Colors.InfoColor = Enum.TryParse(infoStr, out color) ? color : Constants.DebugColor;
			return true;
		}
	}
}
