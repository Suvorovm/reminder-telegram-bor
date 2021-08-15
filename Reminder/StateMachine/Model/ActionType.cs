using System.Xml.Serialization;

namespace Reminder.StateMachine.Model
{
    public enum ActionType
    {
        [XmlEnum("reset")]
        RESET,
        [XmlEnum("fakeSend")]
        FAKE_SEND_MESSAGE
    }


}