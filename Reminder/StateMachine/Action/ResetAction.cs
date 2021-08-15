using System.Collections.Generic;
using Reminder.Core.Repository;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;
using SimpleInjector;

namespace Reminder.StateMachine.Action
{
    public class ResetAction : IAction
    {
        private IRepository<HistoryModel> _historyRepository;
        public IAction Init(Container container)
        {
            _historyRepository = container.GetInstance<IRepository<HistoryModel>>();
            return this;
        }

        /*Удаляем последне действие пользователя, откатывая его на шаг назад*/
        public void Execute(ActionModel actionModel, List<ActionParamDescriptor> actionParamDescriptors)
        {
            HistoryModel historyModel = _historyRepository.Get(actionModel.UserId);
            historyModel.GetLast();
        }
    }
}