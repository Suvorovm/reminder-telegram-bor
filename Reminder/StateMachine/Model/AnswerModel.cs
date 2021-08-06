namespace Reminder.StateMachine.Model
{
    public class AnswerModel
    {
        private string _questionId;
        private string _userAnswer;
        private static AnswerModel Create(string questionId, string userAnswer)
        {
            return new AnswerModel(questionId, userAnswer);
        }

        private AnswerModel(string questionId, string userAnswer)
        {
            _questionId = questionId;
            _userAnswer = userAnswer;
        }

        public string QuestionId
        {
            get { return _questionId; }
        }
        public string UserAnswer
        {
            get { return _userAnswer; }
        }
    }
}