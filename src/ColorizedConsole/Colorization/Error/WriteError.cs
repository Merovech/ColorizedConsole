﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ColorizedConsole
{
	public static partial class ConsoleEx
	{
		public static void WriteError([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(format, arg0));
		}

		public static void WriteError([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(format, arg0));
		}

		public static void WriteError([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(format, arg0));
		}

		public static void WriteError([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(format, arg));
		}

		public static void WriteError(bool value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(char value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(char[]? buffer)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(buffer));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(char[] buffer, int index, int count)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(buffer, index, count));
			Console.Write(buffer, index, count);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(double value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(decimal value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(float value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(int value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(uint value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(long value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(ulong value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(object? value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteError(string? value)
		{
			WriteColorized(Settings.ErrorColor, () => Console.Write(value));
		}
	}
}
