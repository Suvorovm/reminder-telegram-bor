using System.Collections.Generic;
using System.Xml.Serialization;

namespace Reminder.StateMachine.Descriptor
{
    [XmlRoot("botConfig")]
    public class BotDescriptor
    {
        [XmlElement("question")]
        public List<QuestionDescriptor> Questions { get; set; }
    }
}