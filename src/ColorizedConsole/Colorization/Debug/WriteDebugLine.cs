using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine()
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(bool value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(char value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(char[]? buffer)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(buffer));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(char[] buffer, int index, int count)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(buffer, index, count));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(decimal value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(double value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(float value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(int value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(uint value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(long value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(ulong value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(object? value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine(string? value)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(format, arg0));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(format, arg0, arg1));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(format, arg0, arg1, arg2));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebugLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(Settings.DebugColor, () => Console.WriteLine(format, arg));
		}
	}
}
