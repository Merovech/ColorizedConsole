namespace ColorizedConsole.Configuration
{
	internal static class Constants
	{
		/// <summary>
		/// Default color for Debug, when no other settings exist.
		/// </summary>
		public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;

		/// <summary>
		/// Default color for Error, when no other settings exist.
		/// </summary>
		public static readonly ConsoleColor DebugColor = ConsoleColor.Yellow;

		/// <summary>
		/// Default color for Info, when no other settings exist.
		/// </summary>
		public static readonly ConsoleColor InfoColor = ConsoleColor.Green;

		/// <summary>
		/// Environment variable name for DebugColor setting.
		/// </summary>
		public static readonly string DebugEnvironmentVarName = "CCDEBUGCOLOR";

		/// <summary>
		/// Environment variable name for ErrorColor setting.
		/// </summary>
		public static readonly string ErrorEnvironmentVarName = "CCERRORCOLOR";

		/// <summary>
		/// Environment variable name for InfoColor setting.
		/// </summary>
		public static readonly string InfoEnvironmentVarName = "CCINFOCOLOR";

		/// <summary>
		/// Config file name.
		/// </summary>
		public static readonly string ConfigFileName = "cc.config.json";
	}
}
