namespace Croft.Core.Extensions
{
    using System.Linq;
    using System.Reflection;

    using Croft.Core.Attributes;

    /// <summary>
    /// A collection of attribute extensions.
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
        public static string GetDescription(this object obj)
        {
            var type = obj.GetType();
            var memInfo = type.GetTypeInfo().DeclaredMembers;

            var attributes = memInfo.FirstOrDefault(x => x.Name == obj.ToString());
            var attribute =
                attributes?.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DescriptionAttribute));

            return attribute != null ? attribute.ConstructorArguments[0].Value.ToString() : obj.ToString();
        }
    }
}