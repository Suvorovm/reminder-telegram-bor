using System.Collections.Generic;
using System.Xml.Serialization;
using Reminder.StateMachine.Action;

namespace Reminder.StateMachine.Model
{
    public enum ActionType
    {
        [XmlEnum("reset")]
        RESET
    }

    public static class ActionTypeExtension
    {
        private static Dictionary<ActionType, IAction> _actions = new Dictionary<ActionType, IAction>() {
                {ActionType.RESET, new ResetAction()}
        };

        public static IAction GetAction(ActionType actionType)
        {
            return _actions[actionType];
        }
    }
}