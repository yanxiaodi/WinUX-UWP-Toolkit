namespace WinUX.Messaging.Notifications.XmlParts
{
    using System.IO;
    using System.Text;
    using System.Xml;

    using WinUX.Xml;

    using XmlDocument = Windows.Data.Xml.Dom.XmlDocument;

    internal abstract class XmlPartBase
    {
        public string ToXmlString()
        {
            using (var stream = new MemoryStream())
            {
                using (
                    var writer = XmlWriter.Create(
                        stream,
                        new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = false, NewLineOnAttributes = false })
                    )
                {
                    XmlWriterHelper.Write(writer, this);
                }

                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public XmlDocument ToXmlDocument()
        {
            var xml = new XmlDocument();
            xml.LoadXml(this.ToXmlString());
            return xml;
        }
    }
}