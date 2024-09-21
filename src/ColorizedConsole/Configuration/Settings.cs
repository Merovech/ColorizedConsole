using System.Text.Json;
using System.Text.Json.Serialization;

namespace ColorizedConsole.Configuration
{
	public class Settings
	{
		private static readonly ConsoleColor _defaultErrorColor = ConsoleColor.Red;
		private static readonly ConsoleColor _defaultDebugColor = ConsoleColor.Yellow;
		private static readonly ConsoleColor _defaultInfoColor = ConsoleColor.Green;

		private static readonly string _configFileName = "cc.config.json";

		private static readonly JsonSerializerOptions _serializerOptions = new()
		{ 
			Converters = { new ConsoleColorConverter() },
			WriteIndented = true
		};

		/// <summary>
		/// The color for the Debug methods (WriteDebug, WriteDebugLine).  Defaults to ColorConsole.Yellow.
		/// </summary>
		[JsonPropertyName("debug")]
		public ConsoleColor DebugColor { get; set; } = _defaultDebugColor;

		/// <summary>
		/// The color for the Error methods (WriteError, WriteErrorLine).  Defaults to ConsoleColor.Red.
		/// </summary>
		[JsonPropertyName("error")]
		public ConsoleColor ErrorColor { get; set; } = _defaultErrorColor;

		/// <summary>
		/// The color for the Info methods (WriteInfo, WriteInfoLine).  Defaults to ConsoleColor.Green.
		/// </summary>
		[JsonPropertyName("info")]
		public ConsoleColor InfoColor { get; set; } = _defaultInfoColor;

		/// <summary>
		/// Initializes a new instance of the Settings class with default values.
		/// </summary>
		public Settings()
		{
			// Use defaults
		}

		/// <summary>
		/// Initializes a new instance of the Settings class with customized values.
		/// </summary>
		/// <param name="debugColor">The color for the Debug methods.  If null, uses the default.</param>
		/// <param name="errorColor">The color for the Error methods.  If null, uses the default.</param>
		/// <param name="consoleColor">The color for the Info methods.  If null, uses the default.</param>
		public Settings(ConsoleColor? debugColor, ConsoleColor? errorColor, ConsoleColor? consoleColor)
		{
			DebugColor = debugColor ?? _defaultDebugColor;
			ErrorColor = errorColor ?? _defaultErrorColor;
			InfoColor = consoleColor ?? _defaultInfoColor;
		}

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
				if (!(File.Exists(_configFileName)))
				{
					return false;
				}

				using FileStream fileStream = File.OpenRead(_configFileName);
				Settings? parsedSettings = JsonSerializer.Deserialize<Settings>(fileStream, _serializerOptions);

				if (parsedSettings == null)
				{
					// No valid JSON
					return false;
				}

				settings.DebugColor = parsedSettings.DebugColor;
				settings.ErrorColor = parsedSettings.ErrorColor;
				settings.InfoColor = parsedSettings.InfoColor;

				return true;
			}
			catch (Exception)
			{
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
			// Pull from environment variasbles if needed
			settings = new();
			return false;
		}

		/// <summary>
		/// Converts a 1.0 config file (.colorizedconsolerc) to a post-1.0 config file (cc.config.json).
		/// </summary>
		public static void ConvertOldConfigFileIfNecessary()
		{
			// Old format:
			// [setting_name]=[setting_value]
			//
			// New format: JSON
			string oldConfigName = ".colorizedconsolerc";
			if (File.Exists(oldConfigName))
			{
				ConsoleColor? debugValue = null;
				ConsoleColor? errorValue = null;
				ConsoleColor? infoValue = null;
				string[] content = File.ReadAllLines(oldConfigName);

				foreach (var line in content)
				{
					var lineParts = line.Split('=');
					if (Enum.TryParse(lineParts[1], out ConsoleColor color))
					{
						switch (lineParts[0])
						{
							case "Debug":
								debugValue = color;
								break;

							case "Error":
								errorValue = color;
								break;

							case "Info":
								infoValue = color;
								break;

							default:
								break;
						}
					}
				}

				Settings newSettings = new Settings(debugValue, errorValue, infoValue);
				JsonSerializerOptions serializerOptions = new()
				{
					WriteIndented = true
				};

				File.WriteAllText(_configFileName, JsonSerializer.Serialize(newSettings, serializerOptions));
			}
		}
	}
}
