namespace ColorizedConsole.Configuration
{
	internal static class Constants
	{
		public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
		public static readonly ConsoleColor DebugColor = ConsoleColor.Yellow;
		public static readonly ConsoleColor InfoColor = ConsoleColor.Green;

		public static readonly string DebugEnvironmentVarName = "CCDEBUGCOLOR";
		public static readonly string ErrorEnvironmentVarName = "CCERRORCOLOR";
		public static readonly string InfoEnvironmentVarName = "CCINFOCOLOR";

		public static readonly string ConfigFileName = "cc.config.json";
	}
}
