using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;
using SimpleInjector;

namespace Reminder.StateMachine.Handler
{
    public interface IQuestHandler
    {
        IQuestHandler Init(Container container);
        AnswerDescriptor HandelAnswer(string userAnswer, List<AnswerDescriptor> answerDescriptors);
    }
}