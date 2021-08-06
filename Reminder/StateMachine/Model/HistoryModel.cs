using System.Collections.Generic;

namespace Reminder.StateMachine.Model
{
    public class HistoryModel
    {
        private Stack<AnswerModel> _answers = new Stack<AnswerModel>();

        public void Add(AnswerModel answerModel)
        {
            _answers.Push(answerModel);
        }

        public AnswerModel GetLast()
        {
            return _answers.Pop();
        }

        public bool IsEmpty()
        {
            return _answers.Count == 0;
        }
    }
}