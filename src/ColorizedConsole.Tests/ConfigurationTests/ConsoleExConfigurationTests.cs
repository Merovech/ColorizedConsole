using ColorizedConsole.Configuration;
using ColorizedConsole.Configuration.Classes;

namespace ColorizedConsole.Tests.ConfigurationTests
{
	[TestClass]
	public class ConsoleExConfigurationTests
	{
		// The actual testing of parsing from JSON and environment variables is done in SettingsTests.cs, so we won't
		// duplicate them here.  Tests assume that the parsing can be done correctly, and these tests just validate
		// that ConsoleEx gets those values.

		[TestInitialize]
		public void Cleanup()
		{
			// Clear out the environment variables and remove any residual config files
			if (File.Exists(Settings.ConfigFileName))
			{
				File.Delete(Settings.ConfigFileName);
			}

			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, null);
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, null);
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, null);
		}

		[TestMethod]
		public void Defaults_Set_Correctly_With_No_File_Or_Environment_Vars()
		{
			// Ensure the test is truly done with no existing file
			Assert.IsFalse(File.Exists(Settings.ConfigFileName));

			ConsoleEx.ApplySettings();
			Assert.AreEqual(ConsoleColor.Yellow, ConsoleEx.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, ConsoleEx.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, ConsoleEx.InfoColor);

			// Also, when no file exists, a default is created.
			Assert.IsTrue(File.Exists(Settings.ConfigFileName));
		}

		[TestMethod]
		public void Defaults_Set_Correctly_With_File_And_No_Environment_Vars()
		{
			Settings toFile = new()
			{
				Colors =
				{
					DebugColor = ConsoleColor.Blue,
					ErrorColor = ConsoleColor.Black,
					InfoColor = ConsoleColor.White
				}
			};

			toFile.WriteToFile();

			ConsoleEx.ApplySettings();
			Assert.AreEqual(ConsoleColor.Blue, ConsoleEx.DebugColor);
			Assert.AreEqual(ConsoleColor.Black, ConsoleEx.ErrorColor);
			Assert.AreEqual(ConsoleColor.White, ConsoleEx.InfoColor);
		}

		[TestMethod]
		public void Defaults_Set_Correctly_With_No_File_And_Environment_Vars()
		{
			// Ensure the test is truly done with no existing file
			Assert.IsFalse(File.Exists(Settings.ConfigFileName));

			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, ConsoleColor.Cyan.ToString());
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, ConsoleColor.DarkYellow.ToString());
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, ConsoleColor.DarkBlue.ToString());

			ConsoleEx.ApplySettings();
			Assert.AreEqual(ConsoleColor.Cyan, ConsoleEx.DebugColor);
			Assert.AreEqual(ConsoleColor.DarkYellow, ConsoleEx.ErrorColor);
			Assert.AreEqual(ConsoleColor.DarkBlue, ConsoleEx.InfoColor);
		}

		[TestMethod]
		public void Environment_Vars_Take_Precedence_Over_File()
		{
			Settings toFile = new()
			{
				Colors =
				{
					DebugColor = ConsoleColor.Blue,
					ErrorColor = ConsoleColor.Black,
					InfoColor = ConsoleColor.White
				}
			};

			toFile.WriteToFile();

			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, ConsoleColor.Cyan.ToString());
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, ConsoleColor.DarkYellow.ToString());
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, ConsoleColor.DarkBlue.ToString());

			ConsoleEx.ApplySettings();
			Assert.AreEqual(ConsoleColor.Cyan, ConsoleEx.DebugColor);
			Assert.AreEqual(ConsoleColor.DarkYellow, ConsoleEx.ErrorColor);
			Assert.AreEqual(ConsoleColor.DarkBlue, ConsoleEx.InfoColor);
		}

	}
}
