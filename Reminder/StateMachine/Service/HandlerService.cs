using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Handler;
using Reminder.StateMachine.Model;
using SimpleInjector;

namespace Reminder.StateMachine.Service
{
    public class HandlerService
    {
        private readonly Dictionary<HandlerQuestionType, IQuestHandler> _handlers;

        public HandlerService(Container container)
        {
            _handlers = new Dictionary<HandlerQuestionType, IQuestHandler>() {
                    {HandlerQuestionType.COMMON_HANDLER, new CommonHandler().Init(container)},
            };
        }

        public AnswerDescriptor Handle(QuestionDescriptor questionDescriptor, string message, string userId)
        {
            return GetHandler(questionDescriptor.HandlerQuestionType).HandelAnswer(message, questionDescriptor.AnswerDescriptors);
        }

        public IQuestHandler GetHandler(HandlerQuestionType handlerQuestionType)
        {
            return _handlers[handlerQuestionType];
        }
    }
}