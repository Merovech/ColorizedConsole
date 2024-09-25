using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static void Beep()
		{
			Console.Beep();
		}

		[SupportedOSPlatform("windows")]
		public static void Beep(int frequency, int duration)
		{
			Console.Beep(frequency, duration);
		}
	}
}
