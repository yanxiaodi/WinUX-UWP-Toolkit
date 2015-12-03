namespace Croft.Core.Messaging.Notifications
{
    using System;

    public sealed class XmlElementAttribute : Attribute
    {
        public string Name { get; private set; }

        public XmlElementAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name cannot be null or whitespace");

            this.Name = name;
        }
    }
}