using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine()
		{
			Console.WriteLine();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(bool value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(char value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(char[]? buffer)
		{
			Console.WriteLine(buffer);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(char[] buffer, int index, int count)
		{
			Console.WriteLine(buffer, index, count);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(decimal value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(double value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(float value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(int value)
		{
			Console.WriteLine(value);
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(uint value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(long value)
		{
			Console.WriteLine(value);
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(ulong value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(object? value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine(string? value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			Console.WriteLine(format, arg0);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			Console.WriteLine(format, arg0, arg1);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			Console.WriteLine(format, arg0, arg1, arg2);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			Console.WriteLine(format, arg);
		}
	}
}
