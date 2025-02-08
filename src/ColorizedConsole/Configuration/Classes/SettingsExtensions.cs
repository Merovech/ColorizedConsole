using System.Text.Json;

namespace ColorizedConsole.Configuration.Classes
{
	public static class SettingsExtensions
	{
		private static readonly JsonSerializerOptions _serializerOptions = new()
		{
			WriteIndented = true
		};

		public static void WriteToFile(this Settings settings)
		{
			File.WriteAllText(Settings.ConfigFileName, JsonSerializer.Serialize(settings, _serializerOptions));
		}
	}
}
