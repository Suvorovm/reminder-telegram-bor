using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.StateMachine.Action;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;
using SimpleInjector;

namespace Reminder.StateMachine.Service
{
    public class ActionService
    {
        private readonly Dictionary<ActionType, IAction> _actions;

        public ActionService(Container container)
        {
            _actions = new Dictionary<ActionType, IAction>() {
                    {ActionType.RESET, new ResetAction().Init(container)},
                    {ActionType.FAKE_SEND_MESSAGE, new FakeSendMessage().Init(container)},
            };
        }
        
        public IAction GetAction(ActionType actionType)
        {
            return _actions[actionType];
        }

        public void ExecuteActions(ActionModel actionModel, List<ActionDescriptor> descriptors)
        {
            for (int i = 0; i < descriptors.Count; i++) {
                IAction action = GetAction(descriptors[i].ActionType);
                action.Execute(actionModel, descriptors[i].ActionParamDescriptor);
            }
        }

    }
}