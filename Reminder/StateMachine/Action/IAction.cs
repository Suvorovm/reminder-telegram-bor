﻿using System.Collections.Generic;
using Reminder.StateMachine.Descriptor;

namespace Reminder.StateMachine.Action
{
    public interface IAction
    {
        void execute(List<ActionParamDescriptor> actionParamDescriptors);
    }
}