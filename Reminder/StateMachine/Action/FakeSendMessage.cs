using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;
using SimpleInjector;

namespace Reminder.StateMachine.Action
{
    public class FakeSendMessage : IAction
    {
        public IAction Init(Container container)
        {
            return this;
        }

        public void Execute(ActionModel actionModel, List<ActionParamDescriptor> actionParamDescriptors)
        {
            
        }
    }
}