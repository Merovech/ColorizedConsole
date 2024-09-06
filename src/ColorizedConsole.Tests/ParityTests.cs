using System.Reflection;

namespace ColorizedConsole.Tests
{
	/// <summary>
	/// Ensure parity between System.Console and ColorizedConsole.ConsoleEx via reflection.  ConsoleEx
	/// should have more methods and properties, but it should cover every one Console has.
	/// </summary>
	[TestClass]
	public class ParityTests
	{
		[TestMethod]
		public void Validate_Property_Parity()
		{
		}

		[TestMethod]
		public void Validate_Method_Parity()
		{
		}

		[TestMethod]
		public void Validate_Event_Parity()
		{
		}
	}
}