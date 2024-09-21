using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine()
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(bool value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(char value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(char[]? buffer)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(buffer));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(char[] buffer, int index, int count)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(buffer, index, count));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(decimal value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(double value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(float value)
		{
			Console.WriteLine(value);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(int value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(uint value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(long value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(ulong value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(object? value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine(string? value)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(value));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(format, arg0));

		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(format, arg0, arg1));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(format, arg0, arg1, arg2));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfoLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(Settings.InfoColor, () => Console.WriteLine(format, arg));
		}
	}
}
