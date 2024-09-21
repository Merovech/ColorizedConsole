using System.Text.Json;
using ColorizedConsole.Configuration;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		public static Settings Settings
		{
			get; private set;
		}

		static ConsoleEx()
		{
			Settings = new();
			Initialize();
		}

		/// <summary>
		/// Initializes the ConsoleEx class by looking for configuration settings in the local config file (cc.config.json) and then,
		/// if no file was found, in environment variables.  If neither are found, no settings are changed.
		/// </summary>
		public static void Initialize()
		{
			// This may likely never get hit -- it was added only a few days after first release and announcement to the world
			// of this library.  But it's here just in case.
			Settings.ConvertOldConfigFileIfNecessary();

			// Look for a config file first.  If it exists, use that.  Otherwise, look for environment variables.
			// Otherwise, leave everything alone -- on first run the settings will be defaults anyway.

			if (Settings.TryGetFromFile(out Settings settings))
			{
				Settings = settings;
			}
			else if (Settings.TryGetFromEnvironment(out settings))
			{
				Settings = settings;
			}
		}

		// This was the only way I could think to avoid writing the same three lines a million times.
		// I'm open to better options.
		internal static void WriteColorized(ConsoleColor color, Action writeAction)
		{
			ForegroundColor = color;
			writeAction();
			ResetColor();
		}
	}
}
