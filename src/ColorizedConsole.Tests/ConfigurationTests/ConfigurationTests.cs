using ColorizedConsole.Configuration;
using ColorizedConsole.Configuration.Classes;

namespace ColorizedConsole.Tests.ConfigurationTests
{
	[TestClass]
    public class SettingsTests
    {
		[TestCleanup]
		public void Cleanup()
		{
			// Clear out the environment variables and remove any residual config files
			if (File.Exists(Settings.ConfigFileName))
			{
				File.Delete(Settings.ConfigFileName);
			}

			Environment.SetEnvironmentVariable("CCDEBUGCOLOR", null);
			Environment.SetEnvironmentVariable("CCERRORCOLOR", null);
			Environment.SetEnvironmentVariable("CCINFOCOLOR", null);
		}

		[TestMethod]
		public void Defaults_Set_Correctly()
		{
			Settings s = new();
			Assert.AreEqual(s.Colors.DebugColor, ConsoleColor.Yellow);
			Assert.AreEqual(s.Colors.ErrorColor, ConsoleColor.Red);
			Assert.AreEqual(s.Colors.InfoColor, ConsoleColor.Green);
		}

		[TestMethod]
		public void Round_Trips_To_File_Successfully_With_Valid_Json()
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

			Settings.TryGetFromFile(out Settings fromFile);
			Assert.AreEqual(fromFile.Colors.DebugColor, ConsoleColor.Blue);
			Assert.AreEqual(fromFile.Colors.ErrorColor, ConsoleColor.Black);
			Assert.AreEqual(fromFile.Colors.InfoColor, ConsoleColor.White);
		}

		[TestMethod]
		public void Pulls_Successfully_From_Environment_Variables()
		{       
			Environment.SetEnvironmentVariable("CCDEBUGCOLOR", ConsoleColor.Magenta.ToString());
			Environment.SetEnvironmentVariable("CCERRORCOLOR", ConsoleColor.DarkGreen.ToString());
			Environment.SetEnvironmentVariable("CCINFOCOLOR", ConsoleColor.DarkGray.ToString());

			Settings.TryGetFromEnvironment(out Settings fromEnvironment);
			Assert.AreEqual(fromEnvironment.Colors.DebugColor, ConsoleColor.Magenta);
			Assert.AreEqual(fromEnvironment.Colors.ErrorColor, ConsoleColor.DarkGreen);
			Assert.AreEqual(fromEnvironment.Colors.InfoColor, ConsoleColor.DarkGray);
		}
	}
}
