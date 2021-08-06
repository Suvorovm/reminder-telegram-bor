using System.Collections.Generic;
using System.Xml.Serialization;
using Reminder.StateMachine.Model;

namespace Reminder.StateMachine.Descriptor
{
    public class ActionDescriptor
    {
        [XmlAttribute("actionType")]
        public ActionType ActionType { get; set; }
        [XmlElement("param")]
        public List<ActionParamDescriptor> ActionParamDescriptor { get; set; }
    }
}