using System.Text.Json;
using System.Text.Json.Serialization;

namespace ColorizedConsole.Configuration
{
	/// <summary>
	/// Converts a ConsoleColor from a string to an object.  Used for JSON serialization/deserialization.
	/// </summary>
	internal class ConsoleColorConverter : JsonConverter<ConsoleColor?>
	{
		public override ConsoleColor? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return Enum.TryParse<ConsoleColor>(reader.GetString(), true, out var color) ? color : null;
		}

		public override void Write(Utf8JsonWriter writer, ConsoleColor? value, JsonSerializerOptions options)
		{
			if (value != null)
			{
				writer.WriteStringValue(value.ToString());
			}
		}
	}
}
