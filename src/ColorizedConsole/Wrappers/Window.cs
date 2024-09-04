using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		// Passthroughs to the Console, which takes care of the OS stuff
#pragma warning disable CA1416 // Validate platform compatibility
		public static int WindowLeft
		{
			get => Console.WindowLeft;

			[SupportedOSPlatform("windows")]
			set => Console.WindowLeft = value;
		}

		public static int WindowTop
		{
			get => Console.WindowTop;

			[SupportedOSPlatform("windows")]
			set => Console.WindowTop = value;
		}

		public static string Title
		{
			[SupportedOSPlatform("windows")]
			get => Console.Title;
			[UnsupportedOSPlatform("android")]
			[UnsupportedOSPlatform("browser")]
			[UnsupportedOSPlatform("ios")]
			[UnsupportedOSPlatform("tvos")]
			set => Console.Title = value ?? throw new ArgumentNullException(nameof(value));
		}
#pragma warning restore CA1416 // Validate platform compatibility

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static int LargestWindowWidth => Console.LargestWindowWidth;

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static int LargestWindowHeight => Console.LargestWindowHeight;

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static int WindowWidth
		{
			get => Console.WindowWidth;
			set => Console.WindowWidth = value;
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static int WindowHeight
		{
			get => Console.WindowHeight;
			set => Console.WindowHeight = value;
		}

		[SupportedOSPlatform("windows")]
		public static void SetWindowPosition(int left, int top)
		{
			Console.SetWindowPosition(left, top);
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static void SetWindowSize(int width, int height)
		{
			Console.SetWindowSize(width, height);
		}
	}
}
