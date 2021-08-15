using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Reminder.StateMachine.Descriptor
{
    [XmlRoot("botConfig")]
    public class BotDescriptor
    {
        [XmlElement("question")]
        public List<QuestionDescriptor> Questions { get; set; }


        public AnswerDescriptor GetAnswerDescriptorById(string questionId, string answerId)
        {
            QuestionDescriptor question = GetQuestionById(questionId);
            return question.AnswerDescriptors.Find(answerDesc => answerDesc.Id == answerId);
        }
        
        /*TODO: Можно переписать алгоритм поиска. Сейчас очень раздут*/
        public QuestionDescriptor GetQuestionById(string questionId)
        {
            QuestionDescriptor mainQuestions = Questions.FirstOrDefault(descriptor => descriptor.Id == questionId);
            if (mainQuestions != default) {
                return mainQuestions;
            }
            QuestionDescriptor questionDescriptor = null;
            foreach (QuestionDescriptor question in Questions) {
                QuestionDescriptor required = FindQuestionInTree(questionId, question);
                if (required != null) {
                    questionDescriptor = required;
                    break;
                }
            }
            return questionDescriptor;
        }

        private QuestionDescriptor FindQuestionInTree(string questionId, QuestionDescriptor questionDescriptor)
        {
            if (questionDescriptor == null) {
                return null;
            }
            if (questionDescriptor.Id == questionId) {
                return questionDescriptor;
            }
            return FindRecursively(questionId, questionDescriptor.AnswerDescriptors);
        }

        private QuestionDescriptor FindRecursively(string questionId, List<AnswerDescriptor> answerDescriptors)
        {
            QuestionDescriptor questionDescriptor = null;
            for (int i = 0; i < answerDescriptors.Count; i++) {
                QuestionDescriptor question = FindQuestionInTree(questionId, answerDescriptors[i].QuestionDescriptor);
                if (question != null) {
                    questionDescriptor = question;
                }
            }
            return questionDescriptor;
        }

    }
}