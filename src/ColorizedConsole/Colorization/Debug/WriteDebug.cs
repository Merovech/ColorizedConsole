using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		public static void WriteDebug([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(format, arg0));
		}

		public static void WriteDebug([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(format, arg0));
		}

		public static void WriteDebug([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(format, arg0));
		}

		public static void WriteDebug([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(format, arg));
		}

		public static void WriteDebug(bool value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(char value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(char[]? buffer)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(buffer));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(char[] buffer, int index, int count)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(buffer, index, count));
			Console.Write(buffer, index, count);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(double value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(decimal value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(float value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(int value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(uint value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(long value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(ulong value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(object? value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteDebug(string? value)
		{
			WriteColorized(Settings.DebugColor, () => Console.Write(value));
		}
	}
}
