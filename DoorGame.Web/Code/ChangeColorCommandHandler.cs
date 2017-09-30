using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Common.Messaging.Commands;
using Common.Messaging.Events;
using Common.Messaging.Handlers;

namespace Madpoet.Web.Code
{
    [Handles("ChangeColorCommand")]
    public class ChangeColorCommandHandler : ICommandHandler
    {
        private readonly BackgroundData _backgroundData = BackgroundData.GetInstance;

        public async Task<IEvent> Handle(ICommand command)
        {
            var c = command as ChangeColorCommand;

            var success = await _backgroundData.SetColor(c.BoxNum, c.Color);

            if (success) return new ColorChangedEvent(c.BoxNum, c.Color);
            return new ColorChangeFailedEvent();
        }
    }
}