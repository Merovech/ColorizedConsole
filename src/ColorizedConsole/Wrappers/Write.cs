using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			Console.Write(format, arg0);
		}

		public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			Console.Write(format, arg0, arg1);
		}

		public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			Console.Write(format, arg0, arg1, arg2);
		}

		public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			Console.Write(format, arg);
		}

		public static void Write(bool value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(char value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(char[]? buffer)
		{
			Console.Write(buffer);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(char[] buffer, int index, int count)
		{
			Console.Write(buffer, index, count);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(double value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(decimal value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(float value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(int value)
		{
			Console.Write(value);
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(uint value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(long value)
		{
			Console.Write(value);
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(ulong value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(object? value)
		{
			Console.Write(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(string? value)
		{
			Console.Write(value);
		}
	}
}
