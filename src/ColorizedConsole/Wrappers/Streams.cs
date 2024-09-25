using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static TextReader In => Console.In;

		public static TextWriter Out => Console.Out;

		public static TextWriter Error => Console.Error;

		public static bool IsInputRedirected => Console.IsInputRedirected;

		public static bool IsOutputRedirected => Console.IsOutputRedirected;

		public static bool IsErrorRedirected => Console.IsErrorRedirected;

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static void SetIn(TextReader newIn)
		{
			Console.SetIn(newIn);
		}

		public static void SetOut(TextWriter newOut)
		{
			Console.SetOut(newOut);
		}

		public static void SetError(TextWriter newError)
		{
			Console.SetError(newError);
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static Stream OpenStandardInput()
		{
			return Console.OpenStandardInput();
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		public static Stream OpenStandardInput(int bufferSize)
		{
			return Console.OpenStandardInput();
		}

		public static Stream OpenStandardOutput()
		{
			return Console.OpenStandardOutput();
		}

		public static Stream OpenStandardOutput(int bufferSize)
		{
			return Console.OpenStandardOutput();
		}

		public static Stream OpenStandardError()
		{
			return Console.OpenStandardError();
		}

		public static Stream OpenStandardError(int bufferSize)
		{
			return Console.OpenStandardError();
		}
	}
}
