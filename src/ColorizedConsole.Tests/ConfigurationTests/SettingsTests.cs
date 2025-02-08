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

			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, null);
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, null);
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, null);
		}

		[TestMethod]
		public void Defaults_Set_Correctly()
		{
			Settings s = new();
			Assert.AreEqual(ConsoleColor.Yellow, s.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, s.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, s.Colors.InfoColor);

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
			Assert.AreEqual(ConsoleColor.Blue, fromFile.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Black, fromFile.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.White, fromFile.Colors.InfoColor);
		}

		[TestMethod]
		public void Sets_Missing_Value_To_Default_If_Not_In_JSON()
		{
			Settings toFile = new()
			{
				Colors =
				{
					DebugColor = ConsoleColor.Blue,
					InfoColor = ConsoleColor.White
				}
			};

			toFile.WriteToFile();

			Settings.TryGetFromFile(out Settings fromFile);
			Assert.AreEqual(ConsoleColor.Blue, fromFile.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromFile.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.White, fromFile.Colors.InfoColor);
		}

		[TestMethod]
		public void Round_Trips_To_File_With_Defaults_On_Invalid_Color_Value()
		{
			string jsonWithInvalidValues = @"{
				""colors"" : {
					""debugColor"": ""invalid-color"",
					""infoColor"": ""also-invalid-color"",
					""errorColor"": ""also-also-invalid-color""
				}
			}";

			File.WriteAllText(Settings.ConfigFileName, jsonWithInvalidValues);

			Settings.TryGetFromFile(out Settings fromFile);
			Assert.AreEqual(ConsoleColor.Yellow, fromFile.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromFile.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, fromFile.Colors.InfoColor);
		}

		[TestMethod]
		public void Round_Trips_To_File_With_Defaults_On_Partial_Invalid_Color_Value()
		{
			string jsonWithInvalidValues = @"{
				""colors"" : {
					""debugColor"": ""White"",
					""infoColor"": ""also-invalid-color"",
					""errorColor"": ""Blue""
				}
			}";

			File.WriteAllText(Settings.ConfigFileName, jsonWithInvalidValues);

			Settings.TryGetFromFile(out Settings fromFile);
			Assert.AreEqual(ConsoleColor.Yellow, fromFile.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromFile.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, fromFile.Colors.InfoColor);
		}

		[TestMethod]
		public void Round_Trips_To_File_With_Defaults_On_Invalid_Json()
		{
			string jsonWithInvalidValues = @"{
				""colors"" : {
					""debugColor-invalid"": ""invalid-color"",
					""infoColor-invalid"": ""also-invalid-color"",
					""errorColor-invalid"": ""also-also-invalid-color""
				}
			}";

			File.WriteAllText(Settings.ConfigFileName, jsonWithInvalidValues);

			Settings.TryGetFromFile(out Settings fromFile);
			Assert.AreEqual(ConsoleColor.Yellow, fromFile.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromFile.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, fromFile.Colors.InfoColor);
		}

		[TestMethod]
		public void Round_Trips_To_File_With_Defaults_On_Empty_Json()
		{
			string jsonWithInvalidValues = "{}";

			File.WriteAllText(Settings.ConfigFileName, jsonWithInvalidValues);

			Settings.TryGetFromFile(out Settings fromFile);
			Assert.AreEqual(ConsoleColor.Yellow, fromFile.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromFile.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, fromFile.Colors.InfoColor);
		}

		[TestMethod]
		public void Pulls_Successfully_From_Environment_Variables()
		{
			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, ConsoleColor.Magenta.ToString());
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, ConsoleColor.DarkGreen.ToString());
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, ConsoleColor.DarkGray.ToString());

			Settings.TryGetFromEnvironment(out Settings fromEnvironment);
			Assert.AreEqual(ConsoleColor.Magenta, fromEnvironment.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.DarkGreen, fromEnvironment.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.DarkGray, fromEnvironment.Colors.InfoColor);
		}

		[TestMethod]
		public void Reverts_To_Defaults_On_Invalid_Environment_Value()
		{
			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, "invalid-one");
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, "invalid-two");
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, "invalid-three");

			Settings.TryGetFromEnvironment(out Settings fromEnvironment);
			Assert.AreEqual(ConsoleColor.Yellow, fromEnvironment.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromEnvironment.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.Green, fromEnvironment.Colors.InfoColor);
		}

		[TestMethod]
		public void Reverts_To_Default_Only_For_Broken_Environment_Variable()
		{
			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, ConsoleColor.Magenta.ToString());
			Environment.SetEnvironmentVariable(Settings.ErrorEnvironmentVarName, "invalid-color");
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, ConsoleColor.DarkGray.ToString());

			Settings.TryGetFromEnvironment(out Settings fromEnvironment);
			Assert.AreEqual(ConsoleColor.Magenta, fromEnvironment.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromEnvironment.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.DarkGray, fromEnvironment.Colors.InfoColor);
		}

		[TestMethod]
		public void Reverts_To_Default_Only_For_Missing_Environment_Variable()
		{
			Environment.SetEnvironmentVariable(Settings.DebugEnvironmentVarName, ConsoleColor.Magenta.ToString());
			Environment.SetEnvironmentVariable(Settings.InfoEnvironmentVarName, ConsoleColor.DarkGray.ToString());

			Settings.TryGetFromEnvironment(out Settings fromEnvironment);
			Assert.AreEqual(ConsoleColor.Magenta, fromEnvironment.Colors.DebugColor);
			Assert.AreEqual(ConsoleColor.Red, fromEnvironment.Colors.ErrorColor);
			Assert.AreEqual(ConsoleColor.DarkGray, fromEnvironment.Colors.InfoColor);
		}
	}
}
