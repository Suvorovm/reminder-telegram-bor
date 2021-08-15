namespace Reminder.StateMachine.Model
{
    public class AnswerModel
    {
        private string _questionId;
        private string _userAnswer;
        private string _answerId;
        public static AnswerModel Create(string questionId, string userAnswer, string answerId)
        {
            return new AnswerModel(questionId, userAnswer, answerId);
        }

        private AnswerModel(string questionId, string userAnswer, string answerId)
        {
            _questionId = questionId;
            _userAnswer = userAnswer;
            _answerId = answerId;
        }

        public string QuestionId
        {
            get { return _questionId; }
        }
        public string UserAnswer
        {
            get { return _userAnswer; }
        }
        public string AnswerId
        {
            get { return _answerId; }
        }
    }
}