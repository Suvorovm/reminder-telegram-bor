using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;

namespace Reminder.StateMachine.Handler
{
    public interface IQuestHandler
    {
        void HandelAnswer(string userAnswer, List<AnswerDescriptor> answerDescriptors);
    }
}