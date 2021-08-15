using Reminder.StateMachine.Descriptor;

namespace Reminder.StateMachine.Service
{
    public interface IQuestionPrintService
    {
        void PrintQuestion(string userId, QuestionDescriptor questionDescriptor);
    }
}