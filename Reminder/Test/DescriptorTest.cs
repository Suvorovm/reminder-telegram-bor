using NUnit.Framework;
using Reminder.Core.Descriptor;
using Reminder.Core.Service;
using Reminder.StateMachine.Descriptor;

namespace Reminder.Test
{
    [TestFixture]
    public class DescriptorTest
    {
        private DescriptorService _descriptorService;
        private BotDescriptor _botDescriptor;

        [SetUp]
        public void SetUp()
        {
            _descriptorService = new DescriptorService();
            _descriptorService.LoadDescriptor<BotDescriptor>(Descriptors.FAKE_BOT_CONFIG);
            _botDescriptor = _descriptorService.GetDescriptor<BotDescriptor>();
        }

        [Test]
        public void FindQuestion()
        {
            QuestionDescriptor questionDescriptor = _botDescriptor.GetQuestionById("initQuestion");

            Assert.True(questionDescriptor.Id == "initQuestion");
        }

        [Test]
        public void FindIncludedQuestion()
        {
            QuestionDescriptor questionDescriptor = _botDescriptor.GetQuestionById("selectDate");

            Assert.True(questionDescriptor.Id == "selectDate"); 
        }
    }
}