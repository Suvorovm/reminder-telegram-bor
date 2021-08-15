using System.Collections.Generic;

namespace Reminder.StateMachine.Model
{
    public class ActionModel
    {
        public ActionModel()
        {
        }

        public ActionModel(string message, string userId)
        {
            Message = message;
            UserId = userId;
        }

        public ActionModel(string userId)
        {
            UserId = userId;
        }

        public string Message { get; set; }
        public string UserId { get; set; }
        public Dictionary<string, object> ExternalParams { get; set; } = new Dictionary<string, object>();
    }
}