using System.Xml.Serialization;

namespace Reminder.Core.Descriptor
{
    [XmlRoot("webSettings")]
    public class WebSettingsDescriptor
    {
        [XmlAttribute("secretKey")]
        public string SecretKey { get; set; }
    }
}