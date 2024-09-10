namespace ColorizedConsole.Tests.Utilities
{
	/// <summary>
	/// Standardized formats for MemberInfo string representations
	/// </summary>
	internal class HashFormats
	{
		// I should formally document this somewhere.

		// 0 = name
		// 1 = property/value block (a=b&b=c&...)
		public static readonly string Attribute = "[A:{0}|{1}]]";

		// 0 = name
		// 1 = access modifier
		// 2 = method.ToString() output
		// 3 = attribute block (attributeHash&attributeHash...)
		public static readonly string Method = "[M:{0}|{1}|{2}|{{{3}}}]";

		// 0 = name
		// 1 = access modifier
		// 2 = type name
		// 3 = hash of getter and hash of setter (getter&setter)
		// 4 = attribute block (attributeHash&attributeHash...)
		public static readonly string Property = "[P:{0}|{1}|{2}|{{{3}}}|{{{4}}}]";

		// 0 = name
		// 1 = access modifier
		// 3 = hash of add method, hash of remove method, hash of raise method (add&remove&raise)
		// 3 = attribute block (attributeHash&attributeHash...)
		public static readonly string Event = "[E:{0}|{1}|{{{2}}}|{{{3}}}]";
	}
}
