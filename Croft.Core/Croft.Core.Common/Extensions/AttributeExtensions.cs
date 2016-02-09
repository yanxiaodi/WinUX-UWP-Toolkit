namespace WinUX.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    using WinUX.Attributes;

    /// <summary>
    /// A collection of Attribute extensions.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Retrieves the description attribute from an object if it exists.
        /// </summary>
        /// <param name="obj">
        /// The object to retireve the description from.
        /// </param>
        /// <returns>
        /// Returns a string containing the description if the attribute exists, else returns the stringified object.
        /// </returns>
        public static string GetDescriptionAttribute(this object obj)
        {
            var type = obj.GetType();
            var memInfo = type.GetTypeInfo().DeclaredMembers;

            var attributes = memInfo.FirstOrDefault(x => x.Name == obj.ToString());
            var attribute =
                attributes?.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DescriptionAttribute));

            return attribute != null ? attribute.ConstructorArguments[0].Value.ToString() : obj.ToString();
        }

        public static EnumStringAttribute GetEnumStringAttribute(this Enum enumVal)
        {
            return
                enumVal.GetType()
                    .GetTypeInfo()
                    .GetDeclaredField(enumVal.ToString())
                    .GetCustomAttribute<EnumStringAttribute>();
        }
    }
}