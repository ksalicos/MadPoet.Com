using Common.Messaging.Events;

namespace Madpoet.Web.Code
{
    public class ColorChangedEvent : IEvent
    {
        public string type => "COLOR_CHANGED";

        public int BoxNum { get; set; }
        public string Color { get; set; }

        public ColorChangedEvent(int boxNum, string color)
        {
            BoxNum = boxNum;
            Color = color;
        }
    }
}