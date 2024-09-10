using System.Reflection;

namespace ColorizedConsole.Tests.Utilities
{
    /// <summary>
    /// Utility for generating consistent and repeatable string representation of MemberInfo objects that canbe used for comparison or sorting.
    /// </summary>
    internal static class HashUtility
    {
        /// <summary>
        /// Generates a consistent and repeatable string representation of an Attribute that can be used for comparison or sorting.
        /// </summary>
        /// <param name="attribute">The Attribute used to generate the has.</param>
        /// <returns>String</returns>
        public static string GenerateAttributeHash(Attribute attribute)
        {
            // You can put multiple attributes of the same name with different values on a member in any order.
            // So the easiest way to generate a comparable hash of an attribute is to sort those properties and
            // generate them as key/value pairs.
            //
            // Note that when comparing attributes, you don't care about the structure of the properties; you 
            // care about the value.  That's why we do this and not just call GetPropertyHash().
            Type attrType = attribute.GetType();
            string name = attrType.Name;

            // Properties, sorted by name, in key=value form
            string[] hashedProps = attrType
                .GetProperties()
                .OrderBy(p => p.Name)
                .Select(p =>
                {
                    string value = p.GetValue(attribute)?.ToString() ?? string.Empty;
                    return $"{p.Name}={value}";
                }).ToArray();

            // Join the properties with an &, like a URL querystring
            string propsBlock = string.Join('&', hashedProps);

            string hash = string.Format(HashFormats.Attribute, [name, propsBlock]);
            return hash;
        }

        /// <summary>
        /// Generates a consistent and repeatable string representation of a MethodInfo that can be used for comparison or sorting.
        /// </summary>
        /// <param name="method">The MethodInfo used to generate the hash.</param>
        /// <returns>String</returns>
        public static string GenerateMethodHash(MethodInfo? method)
        {
            if (method == null)
            {
                return "_";
            }

            string name = method.Name;
            string accessModifier = GetAccessModifier(method).ToString();
            string methodStr = method.ToString() ?? string.Empty; // I don't know how we'd get null here, but the compiler complained so it's fixed
            string attributeBlock = GenerateAttributeBlock(method);

            string hash = string.Format(HashFormats.Method, name, accessModifier, methodStr, attributeBlock);
            return hash;
        }

        /// <summary>
        /// Generates a consistent and repeatable string representation of a PropoertyInfo that can be used for comparison or sorting.
        /// </summary>
        /// <param name="property">The PropertyInfo used to generate the hash.</param>
        /// <returns>String</returns>
        public static string GeneratePropertyHash(PropertyInfo property)
        {
            string name = property.Name;
            string accessModifier = GetAccessModifier([property.GetMethod, property.SetMethod]);
            string propertyTypeName = property.PropertyType.Name;
            string getterSetterBlock = $"{GenerateMethodHash(property.GetMethod)}&{GenerateMethodHash(property.SetMethod)}";
            string attributeBlock = GenerateAttributeBlock(property);

            string hash = string.Format(HashFormats.Property, name, accessModifier, propertyTypeName, getterSetterBlock, attributeBlock);
            return hash;
        }

        /// <summary>
        /// Generates a consistent and repeatable string representation of an EventInfo that can be used for comparison or sorting.
        /// </summary>
        /// <param name="property">The PropertyInfo used to generate the hash.</param>
        /// <returns>String</returns>
        public static string GenerateEventHash(EventInfo eventInfo)
        {
            string name = eventInfo.Name;
            string accessModifier = GetAccessModifier([eventInfo.AddMethod, eventInfo.RemoveMethod, eventInfo.RaiseMethod]);
            string addRemoveRaiseBlock = $"{GenerateMethodHash(eventInfo.AddMethod)}&{GenerateMethodHash(eventInfo.RemoveMethod)}&{GenerateMethodHash(eventInfo.RaiseMethod)}";
            string attributeBlock = GenerateAttributeBlock(eventInfo);

            string hash = string.Format(HashFormats.Event, name, accessModifier, addRemoveRaiseBlock, attributeBlock);
            return hash;
        }

        private static string GenerateAttributeBlock(MemberInfo member)
        {
            // Sort by name
            string[] hashedAttributes = member
                .GetCustomAttributes()
                .OrderBy(a => a.GetType().Name)
                .Select(a => GenerateAttributeHash(a)).ToArray();

            return string.Join('&', hashedAttributes);
        }

        // Adapted from a trickfound on StackOverflow
        // https://stackoverflow.com/questions/2426134/detect-access-modifier-type-on-a-property-using-reflection
        private static string GetAccessModifier(List<MethodInfo> methods)
        {
            int final = methods.Max(m => (int)GetAccessModifier(m));
            return Enum.GetNames<AccessModifier>()[final];
        }

        private static AccessModifier GetAccessModifier(MethodInfo? m)
        {
            if (m == null)
            {
                return AccessModifier.None;
            }

            if (m.IsPrivate)
            {
                return AccessModifier.Public;
            }

            if (m.IsFamily)
            {
                return AccessModifier.Public;
            }

            if (m.IsFamilyOrAssembly)
            {
                return AccessModifier.Public;
            }

            if (m.IsAssembly)
            {
                return AccessModifier.Public;
            }

            if (m.IsPublic)
            {
                return AccessModifier.Public;
            }

            throw new InvalidOperationException($"No access modifier found for {m.Name}");
        }
    }
}
