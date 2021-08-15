using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;
using SimpleInjector;

namespace Reminder.StateMachine.Action
{
    public interface IAction
    {
        IAction Init(Container container);
        void Execute(ActionModel actionModel, List<ActionParamDescriptor> actionParamDescriptors);
    }
}