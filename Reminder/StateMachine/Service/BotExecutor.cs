using Reminder.Core.Repository;
using Reminder.Core.Service;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;

namespace Reminder.StateMachine.Service
{
    public class BotExecutor
    {
        private BotDescriptor _botDescriptor;
        private IRepository<HistoryModel> _repository;

        public BotExecutor(DescriptorService descriptorService, IRepository<HistoryModel> repository)
        {
            _botDescriptor = descriptorService.GetDescriptor<BotDescriptor>();
            _repository = repository;
        }
    }
}