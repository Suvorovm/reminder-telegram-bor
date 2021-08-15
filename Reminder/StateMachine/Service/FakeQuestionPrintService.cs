using System;
using Reminder.StateMachine.Descriptor;

namespace Reminder.StateMachine.Service
{
    public class FakeQuestionPrintService : IQuestionPrintService
    {
        public void PrintQuestion(string userId, QuestionDescriptor questionDescriptor)
        {
            Console.WriteLine($"UserId {userId}. Message For user {questionDescriptor.Text}. QustionId = {questionDescriptor.Id}");
        }
    }
}