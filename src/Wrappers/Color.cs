using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static ConsoleColor BackgroundColor
		{
			get => Console.BackgroundColor;
			set => Console.BackgroundColor = value;
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static ConsoleColor ForegroundColor
		{
			get => Console.ForegroundColor;
			set => Console.ForegroundColor = value;
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static void ResetColor()
		{
			Console.ResetColor();
		}
	}
}
