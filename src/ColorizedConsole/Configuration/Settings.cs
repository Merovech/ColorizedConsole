using System.Text.Json;
using System.Text.Json.Serialization;

namespace ColorizedConsole.Configuration
{
	public class Settings
	{
		private static readonly ConsoleColor _defaultErrorColor = ConsoleColor.Red;
		private static readonly ConsoleColor _defaultDebugColor = ConsoleColor.Yellow;
		private static readonly ConsoleColor _defaultInfoColor = ConsoleColor.Green;

		private static readonly string _debugEnvironmentVarName = "CCDEBUGCOLOR";
		private static readonly string _errorEnvironmentVarName = "CCERRORCOLOR";
		private static readonly string _infoEnvironmentVarName = "CCINFOCOLOR";

		private static readonly string _configFileName = "cc.config.json";

		private static readonly JsonSerializerOptions _serializerOptions = new()
		{ 
			WriteIndented = true
		};

		/// <summary>
		/// The color for the Debug methods (WriteDebug, WriteDebugLine).  Defaults to ColorConsole.Yellow.
		/// </summary>
		[JsonPropertyName("debugColor")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public ConsoleColor DebugColor { get; set; } = _defaultDebugColor;

		/// <summary>
		/// The color for the Error methods (WriteError, WriteErrorLine).  Defaults to ConsoleColor.Red.
		/// </summary>
		[JsonPropertyName("errorColor")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public ConsoleColor ErrorColor { get; set; } = _defaultErrorColor;

		/// <summary>
		/// The color for the Info methods (WriteInfo, WriteInfoLine).  Defaults to ConsoleColor.Green.
		/// </summary>
		[JsonPropertyName("infoColor")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
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
				if (!File.Exists(_configFileName))
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
			var debugStr = Environment.GetEnvironmentVariable(_debugEnvironmentVarName);
			var errorStr = Environment.GetEnvironmentVariable(_errorEnvironmentVarName);
			var infoStr = Environment.GetEnvironmentVariable(_infoEnvironmentVarName);

			if (debugStr == null && errorStr == null && infoStr == null)
			{
				return false;
			}

			settings.DebugColor = Enum.TryParse(debugStr, out ConsoleColor color) ? color : _defaultDebugColor;
			settings.ErrorColor = Enum.TryParse(errorStr, out color) ? color : _defaultErrorColor;
			settings.InfoColor = Enum.TryParse(infoStr, out color) ? color : _defaultInfoColor;
			return true;
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
					try
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
					catch (Exception)
					{
						// This could happen in the ConsoleEx constructor, so we can't rely on having that and should use Console instead
						Console.WriteLine("Unable to convert config file to the new format.  There was an error parsing the old config file.");
					}
				}

				Settings newSettings = new(debugValue, errorValue, infoValue);
				File.WriteAllText(_configFileName, JsonSerializer.Serialize(newSettings, _serializerOptions));
			}
		}
	}
}
