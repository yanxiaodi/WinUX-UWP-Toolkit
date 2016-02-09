namespace WinUX.Attributes.Xml
{
    using System;

    public sealed class XmlAttributeAttribute : Attribute
    {
        public string Name { get; private set; }

        public object DefaultValue { get; private set; }

        public XmlAttributeAttribute(string name, object defaultValue = null)
        {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}