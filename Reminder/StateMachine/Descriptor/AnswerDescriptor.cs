using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Reminder.StateMachine.Descriptor
{
    public class AnswerDescriptor
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("question")]
        public QuestionDescriptor QuestionDescriptor { get; set; }
        [XmlAttribute("userAnswear")]
        public List<string> UserAnswer { get; set; }

    }
}