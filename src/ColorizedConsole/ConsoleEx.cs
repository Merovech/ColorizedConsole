namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		private static readonly ConsoleColor _defaultErrorColor = ConsoleColor.Red;
		private static readonly ConsoleColor _defaultDebugColor = ConsoleColor.Yellow;
		private static readonly ConsoleColor _defaultInfoColor = ConsoleColor.Green;

		public static ConsoleColor DebugColor { get; set; } = _defaultDebugColor;

		public static ConsoleColor ErrorColor { get; set; } = _defaultErrorColor;

		public static ConsoleColor InfoColor { get; set; } = _defaultInfoColor;

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
