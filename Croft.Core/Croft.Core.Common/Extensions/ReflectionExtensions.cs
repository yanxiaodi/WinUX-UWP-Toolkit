namespace Croft.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Croft.Core.Attributes;

    /// <summary>
    /// A collection of System.Reflection extensions.
    /// </summary>
    public static class ReflectionExtensions
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

        public static IEnumerable<T> GetCustomAttributesOfType<T>(this object obj) where T : Attribute
        {
            var type = obj.GetType();
            return type.GetTypeInfo().GetCustomAttributes().OfType<T>();
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(this object obj)
        {
            var type = obj.GetType();
            return type.GetTypeInfo().DeclaredProperties;
        }

        public static string GetPropertyValueAsString(this object propertyValue)
        {
            var type = propertyValue.GetType();

            if (type.GetTypeInfo().IsEnum)
            {
                var enumObj = propertyValue as Enum;

                var enumStringAttr = enumObj.GetCustomAttributesOfType<EnumStringAttribute>().FirstOrDefault();
                if (enumStringAttr != null)
                {
                    return enumStringAttr.ToString();
                }
            }

            return propertyValue.ToString();
        }
    }
}