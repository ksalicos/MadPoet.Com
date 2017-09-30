using System;
using Common.Messaging.Commands;
using Common.Messaging.Events;

namespace Madpoet.Web.Code
{
    public class InitEvent : IEvent
    {
        public string type => "INIT";
        public string[] Colors { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public InitEvent(string[] colors)
        {
            Colors = colors;
            (Rows, Cols) = BackgroundData.GetInstance.Dims();
        }
    }
}