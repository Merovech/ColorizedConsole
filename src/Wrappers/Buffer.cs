using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		// Passthroughs to the Console, which takes care of the OS stuff
#pragma warning disable CA1416 // Validate platform compatibility
		public static int BufferWidth
		{
			[UnsupportedOSPlatform("android")]
			[UnsupportedOSPlatform("browser")]
			[UnsupportedOSPlatform("ios")]
			[UnsupportedOSPlatform("tvos")]
			get => Console.BufferWidth;

			[SupportedOSPlatform("windows")]
			set => Console.BufferWidth = value;
		}

		public static int BufferHeight
		{
			[UnsupportedOSPlatform("android")]
			[UnsupportedOSPlatform("browser")]
			[UnsupportedOSPlatform("ios")]
			[UnsupportedOSPlatform("tvos")]
			get => Console.BufferHeight;

			[SupportedOSPlatform("windows")]
			set => Console.BufferHeight = value;
		}
#pragma warning restore CA1416 // Validate platform compatibility

		[SupportedOSPlatform("windows")]
		public static void SetBufferSize(int width, int height)
		{
			Console.SetBufferSize(width, height);
		}

		[SupportedOSPlatform("windows")]
		public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
		{
			Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, ' ', ConsoleColor.Black, BackgroundColor);
		}

		[SupportedOSPlatform("windows")]
		public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
		{
			Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static void Clear()
		{
			Console.Clear();
		}
	}
}
