using System;
using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;
using SimpleInjector;

namespace Reminder.StateMachine.Handler
{
    public class CommonHandler : IQuestHandler
    {
        public IQuestHandler Init(Container container)
        {
            return this;
        }

        
        public AnswerDescriptor HandelAnswer(string userAnswer, List<AnswerDescriptor> answerDescriptors)
        {
            return answerDescriptors.Find(d => d.UserAnswer.Contains(userAnswer) || d.UserAnswer.Count == 0);
        }
    }
}