using ColorizedConsole;

ConsoleEx.WriteLine("Demo: Default behavior");

// Wrapping System.Console, so behavior is identical
ConsoleEx.WriteLine("Press any key to begin demo.");
ConsoleEx.ReadKey();
ConsoleEx.WriteLine();

// Normal WriteLine with a custom color
ConsoleEx.WriteLine(ConsoleColor.Cyan, "Beginning demo.");

WriteCount(false);
WriteCount(true);

// Normal WriteLine with a custom color
ConsoleEx.WriteLine(ConsoleColor.Cyan, "Demo complete.");

// Wrapping System.Console, so behavior is identical
ConsoleEx.WriteLine();
ConsoleEx.WriteLine("Press enter to exit...");
ConsoleEx.ReadLine();

void WriteCount(bool error)
{
	// Exercise not only normal System.Console behavior, but the WriteDebug/WriteDebugLine, WriteInfo/WriteInfoLine, and WriteError/WriteErrorLine 
	// methods which are unique to ColorizedConsole.ConsoleEx.
	for (int i = 0; i <= 100; i++)
	{
		// Anything System.Console can do, ColorizedConsole.ConsoleEx can do
		ConsoleEx.SetCursorPosition(0, ConsoleEx.CursorTop);
		ConsoleEx.Write($"Performing some action that may succeed... {i}%");

		Thread.Sleep(25);
	}

	ConsoleEx.SetCursorPosition(0, ConsoleEx.CursorTop);
	ConsoleEx.Write("Performing some action that may succeed... ");
	if (error)
	{
		ConsoleEx.WriteErrorLine("failed!");
	}
	else
	{
		ConsoleEx.WriteInfoLine("succeeded!");
	}

	ConsoleEx.WriteDebug("The action ");
	if (error)
	{
		ConsoleEx.WriteError("failed");
		ConsoleEx.WriteDebugLine(".  Boo!");
	}
	else
	{
		ConsoleEx.WriteInfo("succeeded");
		ConsoleEx.WriteDebugLine(".  Yay!");
	}
}