using System.Runtime.Versioning;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		public static event ConsoleCancelEventHandler? CancelKeyPress
		{
			add => Console.CancelKeyPress += value;
			remove => Console.CancelKeyPress -= value;
		}

		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("browser")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		public static bool TreatControlCAsInput
		{
			get => Console.TreatControlCAsInput;
			set => Console.TreatControlCAsInput = value;
		}

		[SupportedOSPlatform("windows")]
		public static bool NumberLock => Console.NumberLock;

		[SupportedOSPlatform("windows")]
		public static bool CapsLock => Console.CapsLock;

		public static bool KeyAvailable => Console.KeyAvailable;
	}
}
