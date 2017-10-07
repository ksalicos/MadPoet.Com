using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Common.Messaging.Callbacks;
using Common.Messaging.Commands;
using Common.Messaging.Dispatchers;
using DoorGame.Web.Code.FlashyBackground;
using Madpoet.Web.Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace Madpoet.Web.Hubs
{
    public class aHub : Hub
    {
        static aHub()
        {
            _dispatcher.RegisterHandler(new ChangeColorCommandHandler());
        }

        private static readonly IDispatcher _dispatcher = new ImmediateDispatcher();
        private string Id => Context.User.Identity.GetUserId();
        private readonly BackgroundData _backgroundData = BackgroundData.GetInstance;

        private async Task Dispatch(ICommand c, SignalRCallback.Audience audience)
        {
            await _dispatcher.Dispatch(c, new SignalRCallback(Context.ConnectionId, audience));
        }

        public async Task Hello()
        {
            Clients.All.hello();
        }

        public async Task Initialize()
        {            
            Clients.Caller.Dispatch(new InitEvent(_backgroundData.Colors));
        }

        public async Task ChangeColor(int boxNum, string color)
        {
            var command = new ChangeColorCommand(boxNum, color);
            await Dispatch(command, SignalRCallback.Audience.All);
        }
    }
}