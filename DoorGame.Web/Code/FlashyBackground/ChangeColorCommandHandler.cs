using System.Threading.Tasks;
using Common.Messaging.Commands;
using Common.Messaging.Events;
using Common.Messaging.Handlers;

namespace DoorGame.Web.Code.FlashyBackground
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