using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		public static void WriteInfo([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(InfoColor, () => Console.Write(format, arg0));
		}

		public static void WriteInfo([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(InfoColor, () => Console.Write(format, arg0));
		}

		public static void WriteInfo([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(InfoColor, () => Console.Write(format, arg0));
		}

		public static void WriteInfo([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(InfoColor, () => Console.Write(format, arg));
		}

		public static void WriteInfo(bool value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(char value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(char[]? buffer)
		{
			WriteColorized(InfoColor, () => Console.Write(buffer));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(char[] buffer, int index, int count)
		{
			WriteColorized(InfoColor, () => Console.Write(buffer, index, count));
			Console.Write(buffer, index, count);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(double value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(decimal value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(float value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(int value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(uint value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(long value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(ulong value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(object? value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteInfo(string? value)
		{
			WriteColorized(InfoColor, () => Console.Write(value));
		}
	}
}
