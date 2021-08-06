using System.Collections.Generic;
using System.Xml.Serialization;

namespace Reminder.StateMachine.Descriptor
{
    public class AnswerDescriptor
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("question")]
        public QuestionDescriptor QuestionDescriptor { get; set; }
        [XmlElement("userAnswear")]
        public List<string> UserAnswer { get; set; }
    }
}