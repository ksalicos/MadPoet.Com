using Common.Messaging.Events;

namespace DoorGame.Web.Code.FlashyBackground
{
    public class ColorChangeFailedEvent : IEvent
    {
        public string type => "COLOR_CHANGE_FAILED";
    }
}