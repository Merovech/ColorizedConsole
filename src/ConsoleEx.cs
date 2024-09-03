namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		private static readonly string _configFileName = ".colorcrc";

		public static ConsoleColor DebugColor { get; private set; }

		public static ConsoleColor ErrorColor { get; private set; }

		public static ConsoleColor InfoColor { get; private set; }

		static ConsoleEx()
		{
			if (File.Exists(_configFileName))
			{
				var configLines = File.ReadAllLines(_configFileName);
				foreach (var line in configLines) {
					ConsoleColor? parsedColor = GetConsoleColor(line);
					// Fall back to whatever the default console color is in the case of no config
					// or invalid values in the config.
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
					else
					{
						ErrorColor = Console.ForegroundColor;
						DebugColor = Console.ForegroundColor;
						InfoColor = Console.ForegroundColor;
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
