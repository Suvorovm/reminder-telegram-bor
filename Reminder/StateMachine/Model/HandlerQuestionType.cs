using System.Collections.Generic;
using System.Xml.Serialization;
using Reminder.StateMachine.Handler;

namespace Reminder.StateMachine.Model
{
    public enum HandlerQuestionType
    {
        [XmlEnum("confirmHandler")]
        CONFIRM_HANDLER = 0,
        [XmlEnum("commonHandler")]
        COMMON_HANDLER = 1
        
    }


}