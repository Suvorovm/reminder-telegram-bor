using System.Collections.Generic;
using System.Xml.Serialization;
using Reminder.StateMachine.Model;

namespace Reminder.StateMachine.Descriptor
{
    public class QuestionDescriptor
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("text")]
        public string Text { get; set; }
        [XmlAttribute("handler")]
        public HandlerQuestionType HandlerQuestionType { get; set; }
        [XmlElement("answear")]
        public List<AnswerDescriptor> AnswerDescriptors { get; set; }
        [XmlElement("action")]
        public List<ActionDescriptor> ActionDescriptors { get; set; }
    }
}