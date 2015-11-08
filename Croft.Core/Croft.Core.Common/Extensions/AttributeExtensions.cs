namespace Croft.Core.Extensions
{
    using System.Linq;
    using System.Reflection;

    using Croft.Core.Attributes;

    public static class AttributeExtensions
    {
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