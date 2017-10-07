using System;
using Common.Messaging.Commands;

namespace DoorGame.Web.Code.FlashyBackground
{
    public class ChangeColorCommand : ICommand
    {
        public Guid CommandId { get; } = Guid.NewGuid();

        public int BoxNum { get; set; }
        public string Color { get; set; }

        public ChangeColorCommand(int boxNum, string color)
        {
            BoxNum = boxNum;
            Color = color;
        }
    }
}