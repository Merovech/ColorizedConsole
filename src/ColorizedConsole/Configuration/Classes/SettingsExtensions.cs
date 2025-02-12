using System.Text.Json;

namespace ColorizedConsole.Configuration.Classes
{
	public static class SettingsExtensions
	{
		private static readonly JsonSerializerOptions _serializerOptions = new()
		{
			WriteIndented = true
		};

		/// <summary>
		/// Writes settings to a JSON file using attributes defined on the Settings object.  Always writes to "cc.config.json".
		/// </summary>
		/// <param name="settings">The settings to write to file.</param>
		public static void WriteToFile(this Settings settings)
		{
			File.WriteAllText(Settings.ConfigFileName, JsonSerializer.Serialize(settings, _serializerOptions));
		}
	}
}
