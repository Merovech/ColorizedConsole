using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine()
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(bool value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(char value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(char[]? buffer)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(buffer));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(char[] buffer, int index, int count)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(buffer, index, count));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(decimal value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(double value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(float value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(int value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(uint value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(long value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(ulong value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(object? value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine(string? value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(format, arg0));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(format, arg0, arg1));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(format, arg0, arg1, arg2));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteErrorLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(Settings.ErrorColor, () => Console.WriteLine(format, arg));
		}
	}
}
