using Common.Messaging.Events;

namespace Madpoet.Web.Code
{
    public class ColorChangeFailedEvent : IEvent
    {
        public string type => "COLOR_CHANGE_FAILED";
    }
}