using System.Xml.Serialization;

namespace Reminder.StateMachine.Descriptor
{
    public class ActionParamDescriptor
    {
        [XmlAttribute("key")]
        public string Key { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}