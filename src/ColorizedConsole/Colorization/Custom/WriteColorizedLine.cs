using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		public static void WriteLine(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(color, () => Console.WriteLine(format, arg0));
		}

		public static void WriteLine(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(color, () => Console.WriteLine(format, arg0, arg1));
		}

		public static void WriteLine(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(color, () => Console.WriteLine(format, arg0, arg1, arg2));
		}

		public static void WriteLine(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(color, () => Console.WriteLine(format, arg));
		}

		public static void WriteLine(ConsoleColor color, bool value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, char value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, char[]? buffer)
		{
			WriteColorized(color, () => Console.WriteLine(buffer));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, char[] buffer, int index, int count)
		{
			WriteColorized(color, () => Console.WriteLine(buffer, index, count));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, double value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, decimal value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, float value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, int value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, uint value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, long value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, ulong value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, object? value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ConsoleColor color, string? value)
		{
			WriteColorized(color, () => Console.WriteLine(value));
		}
	}
}

