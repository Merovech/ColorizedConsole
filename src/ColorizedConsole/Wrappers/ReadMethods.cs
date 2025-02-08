using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		public static int Read()
		{
			return Console.In.Read();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		public static string? ReadLine()
		{
			return Console.In.ReadLine();
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static ConsoleKeyInfo ReadKey()
		{
			return Console.ReadKey(false);
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static ConsoleKeyInfo ReadKey(bool intercept)
		{
			return Console.ReadKey(intercept);
		}
	}
}