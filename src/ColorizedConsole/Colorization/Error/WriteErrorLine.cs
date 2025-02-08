using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public partial class ConsoleEx
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine()
		{
			WriteColorized(ErrorColor, () => Console.WriteLine());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(bool value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(char value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(char[]? buffer)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(buffer));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(char[] buffer, int index, int count)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(buffer, index, count));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(decimal value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(double value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(float value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(int value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(uint value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(long value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(ulong value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(object? value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(string? value)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(format, arg0));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(format, arg0, arg1));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(format, arg0, arg1, arg2));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(ErrorColor, () => Console.WriteLine(format, arg));
		}
	}
}
