namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		private static readonly string _configFileName = ".colorizedconsolerc";
		private static readonly ConsoleColor _defaultErrorColor = ConsoleColor.Red;
		private static readonly ConsoleColor _defaultDebugColor = ConsoleColor.Yellow;
		private static readonly ConsoleColor _defaultInfoColor = ConsoleColor.Green;

		public static ConsoleColor DebugColor { get; private set; } = _defaultDebugColor;

		public static ConsoleColor ErrorColor { get; private set; } = _defaultErrorColor;

		public static ConsoleColor InfoColor { get; private set; } = _defaultInfoColor;

		static ConsoleEx()
		{
			if (File.Exists(_configFileName))
			{
				var configLines = File.ReadAllLines(_configFileName);
				foreach (var line in configLines) {
					// Fallbacks are defined above
					ConsoleColor? parsedColor = GetConsoleColor(line);
					if (line.StartsWith("Debug"))
					{
						DebugColor = parsedColor ?? Console.ForegroundColor;
					}
					else if (line.StartsWith("Error"))
					{
						ErrorColor = parsedColor ?? Console.ForegroundColor;
					}
					else if (line.StartsWith("Info"))
					{
						InfoColor = parsedColor ?? Console.ForegroundColor;
					}
				}
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

		private static ConsoleColor? GetConsoleColor(string line)
		{
			string colorString = line[(line.IndexOf('=') + 1)..];
			return Enum.TryParse(colorString, out ConsoleColor color) ?	color : null;
		}
	}
}
