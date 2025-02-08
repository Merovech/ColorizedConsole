using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		public static void Write(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(color, () => Console.Write(format, arg0));
		}

		public static void Write(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(color, () => Console.Write(format, arg0, arg1));
		}

		public static void Write(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(color, () => Console.Write(format, arg0, arg1, arg2));
		}

		public static void Write(ConsoleColor color, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(color, () => Console.Write(format, arg));
		}

		public static void Write(ConsoleColor color, bool value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, char value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, char[]? buffer)
		{
			WriteColorized(color, () => Console.Write(buffer));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, char[] buffer, int index, int count)
		{
			WriteColorized(color, () => Console.Write(buffer, index, count));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, double value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, decimal value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, float value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, int value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, uint value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, long value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, ulong value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, object? value)
		{
			WriteColorized(color, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ConsoleColor color, string? value)
		{
			WriteColorized(color, () => Console.Write(value));
		}
	}
}

