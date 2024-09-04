using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
#pragma warning disable CA1416 // Validate platform compatibility
		public static bool CursorVisible
		{
			// Passthrough to the Console, which takes care of the OS stuff
			[SupportedOSPlatform("windows")]
			get => Console.CursorVisible;

			[UnsupportedOSPlatform("android")]
			[UnsupportedOSPlatform("browser")]
			[UnsupportedOSPlatform("ios")]
			[UnsupportedOSPlatform("tvos")]
			set => Console.CursorVisible = value;
		}

		public static int CursorSize
		{
			[UnsupportedOSPlatform("android")]
			[UnsupportedOSPlatform("browser")]
			[UnsupportedOSPlatform("ios")]
			[UnsupportedOSPlatform("tvos")]
			get
			{
				return Console.CursorSize;
			}
			[SupportedOSPlatform("windows")]
			set
			{
				Console.CursorSize = value;
			}
		}
#pragma warning restore CA1416 // Validate platform compatibility

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static int CursorLeft
		{
			get => GetCursorPosition().Left;
			set => SetCursorPosition(value, CursorTop);
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static int CursorTop
		{
			get => GetCursorPosition().Top;
			set => SetCursorPosition(CursorLeft, value);
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static (int Left, int Top) GetCursorPosition()
		{
			return Console.GetCursorPosition();
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static void SetCursorPosition(int left, int top)
		{
			Console.SetCursorPosition(left, top);
		}
	}
}
