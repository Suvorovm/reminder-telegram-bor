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

    public static class HandlerQuestionTypeExtension
    {
        private static Dictionary<HandlerQuestionType, IQuestHandler> _handlers = new Dictionary<HandlerQuestionType, IQuestHandler>() {
                {HandlerQuestionType.COMMON_HANDLER, new CommonHandler()},
        };

        public static IQuestHandler GetHandler(HandlerQuestionType handlerQuestionType)
        {
            return _handlers[handlerQuestionType];
        }
    }

}