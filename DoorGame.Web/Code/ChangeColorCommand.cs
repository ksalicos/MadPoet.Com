using System;
using Common.Messaging.Commands;

namespace Madpoet.Web.Code
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