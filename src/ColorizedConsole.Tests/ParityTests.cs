// TODO: Come up with more tests.  But since both Console and ConsoleEx are static, that's tricky.  We can't mock, for example.
using System.Reflection;
using ColorizedConsole.Tests.Utilities;

namespace ColorizedConsole.Tests
{
	/// <summary>
	/// Ensure parity between System.Console and ColorizedConsole.ConsoleEx via reflection.  ConsoleEx
	/// should have more methods and properties, but it should cover every one Console has.
	/// </summary>
	[TestClass]
	public class ParityTests
	{
		/// <summary>
		/// Validates that all properties in Console are covered by ConsoleEx.
		/// </summary>
		[TestMethod]
		public void Validate_Property_Parity()
		{
			PropertyInfo[] consoleProps = typeof(Console).GetProperties();
			PropertyInfo[] consoleExProps = typeof(ConsoleEx).GetProperties();
			RunTest(consoleProps, consoleExProps, HashUtility.GeneratePropertyHash);

		}

		/// <summary>
		/// Validates that all methods (and overloads) in Console are covered by ConsoleEx.
		/// </summary>
		[TestMethod]
		public void Validate_Method_Parity()
		{
			MethodInfo[] consoleMethods = typeof(Console).GetMethods();
			MethodInfo[] consoleExMethods = typeof(ConsoleEx).GetMethods();
			RunTest(consoleMethods, consoleExMethods, HashUtility.GenerateMethodHash);
		}

		/// <summary>
		/// Validates that all events in Console are covered by ConsoleEx.
		/// </summary>
		[TestMethod]
		public void Validate_Event_Parity()
		{
			EventInfo[] consoleEvents = typeof(Console).GetEvents();
			EventInfo[] consoleExEvents = typeof(ConsoleEx).GetEvents();
			RunTest(consoleEvents, consoleEvents, HashUtility.GenerateEventHash);
		}

		/// <summary>
		/// Validates that all Attributes on Console are on ConsoleEx.
		/// </summary>
		[TestMethod]
		public void Validate_Attribute_Parity()
		{
			// I can't quite figure out where the two attributes are added to either class, but as they're NullableAttribute and NullableContextAttribute,
			// they appear to be added automatically by the CLR at some point.  Possibly by the compiler.

			// Unfortunately, attributes need to be compared by the values of their properties, and Attribute does not share
			// a base class with MethodInfo, PropertyInfo, or EventInfo.  So we can't take advantage of RunTest().
			List<Attribute> consoleAttributes = typeof(Console).GetCustomAttributes().ToList();
			Dictionary<string, string> consoleDict = consoleAttributes.ToDictionary(a => HashUtility.GenerateAttributeHash(a), a => a.GetType().Name);
			List<Attribute> consoleExAttributes = typeof(ConsoleEx).GetCustomAttributes().ToList();

			ConsoleEx.WriteInfoLine($"Members in dict: {consoleDict.Keys.Count}");
			ConsoleEx.WriteInfoLine(string.Join('\n', consoleDict.Values));

			foreach (Attribute consoleExAttribute in consoleExAttributes)
			{
				string hash = HashUtility.GenerateAttributeHash(consoleExAttribute);
				consoleDict.Remove(hash);
			}

			if (consoleDict.Count != 0)
			{
				Console.WriteLine($"The following attributes were not covered by ConsoleEx:\n{string.Join('\n', consoleDict.Values)}");
				Assert.Fail("Certain attributes were not covered by ConsoleEx.");
			}
		}

		/// <summary>
		/// Runs a test using MemberInfo objects.
		/// </summary>
		/// <typeparam name="TMemberType">A type that inherits from MemberInfo (or MemberInfo itself).</typeparam>
		/// <param name="expected">The expected list of members.</param>
		/// <param name="actual">The actual list of members.</param>
		/// <param name="hashGenerator">A method that takes a MemberInfo and outputs a string for comparison purposes.</param>
		private static void RunTest<TMemberType>(TMemberType[] expected, TMemberType[] actual, Func<TMemberType, string> hashGenerator) where TMemberType : MemberInfo
		{
			ConsoleEx.WriteInfoLine($"Expected count: {expected.Length}");
			ConsoleEx.WriteInfoLine($"Actual count: {actual.Length}");

			// Generate a dictionary.  The key is the actual hash of the member and is used for fast comparison.  The value is the name of the member and is used
			// to generate a list of items that were missed.
			Dictionary<string, string> dict = expected.ToDictionary(m => hashGenerator(m), m => m.Name);

			ConsoleEx.WriteInfoLine($"Members in dict: {dict.Keys.Count}");

			foreach (var member in actual)
			{
				// Hash the item in actual, then see if it's in the dict.  If it is, remove it; if not, leave it alone.
				string hash = hashGenerator(member);

				// Remove() returns true if the item was removed and false if it doesn't.  We don't care about the result; we just care that it tried and didn't
				// throw an exception.  It doesn't, so this line is fine.
				dict.Remove(hash);
			}

			// If the dictionary of expected items is empty here, then every item in expected was accounted for in actual.  Since the tests should be using
			// Console members as the expected list and ConsoleEx members as the actual list, that means that the items that would be left over are the ones that
			// are unique to ConsoleEx, and that's what we're looking for.
			if (dict.Count != 0)
			{
				Console.WriteLine($"The following members were not covered by ConsoleEx:\n{string.Join('\n', dict.Values)}");
				Assert.Fail("Certain members were not covered by ConsoleEx.");
			}
		}
	}
}