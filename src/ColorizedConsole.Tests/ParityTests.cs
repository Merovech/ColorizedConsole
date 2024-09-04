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
		// TO DO: Write a comparer, man.  Seriously.  This is ridiculous.

		[TestMethod]
		public void Validate_Property_Parity()
		{
			var consoleProps = typeof(Console).GetProperties(BindingFlags.Static | BindingFlags.Public);
			var consoleMap = ConvertToDictionary<PropertyInfo>(p => p.Name, consoleProps.ToList());

			var consoleExProps = typeof(ConsoleEx).GetProperties(BindingFlags.Static | BindingFlags.Public);

			foreach (var exProp in consoleExProps)
			{
				var found = consoleMap.TryGetValue(exProp.Name, out var consoleProp);
				if (!found || consoleProp is null) 
				{ 
					continue; 
				}

				
				for (int i = consoleProp.Count - 1; i >= 0; i--)
				{
					var cp = consoleProp[i];
					if (cp is not null && ArePropsEqual(exProp, cp))
					{
						consoleMap[exProp.Name].RemoveAt(i);
						if (consoleMap[exProp.Name].Count == 0)
						{
							consoleMap.Remove(exProp.Name);
						}
					}
				}
			}

			Assert.AreEqual(0, consoleMap.Count, $"{consoleMap.Count} items were not accounted for in ConsoleEx.");
		}

		private Dictionary<string, List<TValue>> ConvertToDictionary<TValue>(Func<TValue, string> keySelector, List<TValue> values)
		{
			Dictionary<string, List<TValue>> retDict = [];

			foreach (TValue v in values)
			{
				var key = keySelector(v);
				if (!retDict.ContainsKey(key))
				{
					retDict.Add(key, new List<TValue>());				
				}

				retDict[key].Add(v);
			}

			return retDict;
		}

		private bool ArePropsEqual(PropertyInfo exProp, PropertyInfo consoleProp)
		{
			if (exProp.Name != consoleProp.Name)
			{
				return false;
			}

			if (exProp.PropertyType != consoleProp.PropertyType)
			{
				return false;
			}

			if (!AreMethodsEqual(exProp.GetMethod, consoleProp.GetMethod))
			{
				return false;
			}

			if (!AreMethodsEqual(exProp.SetMethod, consoleProp.SetMethod))
			{
				return false;
			}
			
			return true;
		}

		private bool AreMethodsEqual(MethodInfo? exMethod, MethodInfo? consoleMethod)
		{
			if (exMethod is null && consoleMethod is null)
			{
				return true;
			}

			if (exMethod is null || consoleMethod is null)
			{
				return false;
			}

			if (GetMethodVisibility(exMethod) != GetMethodVisibility(consoleMethod))
			{
				return false;
			}

			if (!AreAttributesEqual(exMethod.GetCustomAttributes().ToList(), consoleMethod.GetCustomAttributes().ToList()))
			{
				return false;
			}

			return true;
		}

		private bool AreAttributesEqual(List<Attribute> exAttribs, List<Attribute> consoleAttribs)
		{
			// Problem here is that for multiple attributes of the same name we can't guarantee order.  Also, this is
			// WAY overcomplicated and probably badly non-performant.
			//
			// So one possibility:
			//
			// For each attribute on Console
			// 1. Get the name
			// 2. Get all properties
			// 3. Create a string hash that should be unique: "a.Name|prop=val&prop=val..."
			// Build a hashmap out of that.
			//  
			// For each attribute on ConsoleEx
			// 1. Build the same hash as above
			// 2. Look in the hashmap
			// 3. If found, remove the hash from the hashmap; otherwise continue
			//
			// Resulting hashmap should be empty.
			// TODO: Keep a running global list of errors to append to the test output.
			var consoleTypeMap = ConvertToDictionary(a => a.GetType().Name, consoleAttribs);

			foreach (var exAttr in exAttribs)
			{
				Type exType = exAttr.GetType();
				PropertyInfo[] exTypeProps = exType.GetProperties();
				if (consoleTypeMap.ContainsKey(exType.Name))
				{
					List<Attribute> consoleAttr = consoleTypeMap[exType.Name];
					foreach (var consoleAttrProp in consoleAttr)
					{

						PropertyInfo[] consoleAttrTypeProps = consoleAttrProp.GetType().GetProperties();
						if (exTypeProps.Length != consoleAttrTypeProps.Length)
						{
							// Attributes don't match
							return false;
						}

						Array.Sort(exTypeProps, (a, b) => a.Name.CompareTo(b.Name));
						Array.Sort(consoleAttrTypeProps, (a, b) => a.Name.CompareTo(b.Name));

						for (int i = 0; i < exTypeProps.Length; i++)
						{
							if (exTypeProps[i].GetValue(exAttr)?.ToString() != consoleAttrTypeProps[i].GetValue(consoleAttrProp)?.ToString())
							{
								// Attribute values don't match
								return false;
							}
						}
					}
				}
			}

			// If we got all the way here, the lists are equal
			return true;
		}

		private string GetMethodVisibility(MethodInfo m)
		{
			string visibility = "";
			if (m.IsPublic)
			{
				return "Public";
			}
			else if (m.IsPrivate)
			{
				return "Private";
			}
			else
			{
				if (m.IsFamily)
				{
					visibility = "Protected ";
				}
				else if (m.IsAssembly)
				{
					visibility += "Assembly";
				}
			}
			return visibility;
		}
	}
}