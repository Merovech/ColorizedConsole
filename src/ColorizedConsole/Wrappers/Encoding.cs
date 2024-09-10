using System.Runtime.Versioning;
using System.Text;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{

		public static Encoding OutputEncoding
		{
			get => Console.OutputEncoding;

			[UnsupportedOSPlatform("android")]
			[UnsupportedOSPlatform("ios")]
			[UnsupportedOSPlatform("tvos")]
			set => Console.InputEncoding = value;
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static Encoding InputEncoding
		{
			get => Console.InputEncoding;
			set => Console.InputEncoding = value;
		}
	}
}
