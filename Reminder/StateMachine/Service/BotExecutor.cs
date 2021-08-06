using Reminder.Core.Service;
using Reminder.StateMachine.Descriptor;

namespace Reminder.StateMachine.Service
{
    public class BotExecutor
    {
        private BotDescriptor _botDescriptor;
        
        public BotExecutor(DescriptorService descriptorService)
        {
            _botDescriptor = descriptorService.GetDescriptor<BotDescriptor>();
        }
    }
}