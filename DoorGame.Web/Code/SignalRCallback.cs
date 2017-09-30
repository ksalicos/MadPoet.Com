using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Messaging.Callbacks;
using Common.Messaging.Events;
using Madpoet.Web.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Madpoet.Web.Code
{
    public class SignalRCallback : ICallback
    {
        private string ConnectionId { get; set; }
        private Audience Target { get; set; }

        public enum Audience
        {
            Caller,
            All
        }

        public SignalRCallback(string connectionId, Audience audience)
        {
            ConnectionId = connectionId;
            Target = audience;
        }

        public void Callback(IEvent response)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<aHub>();
            switch (Target)
            {
                case Audience.All:
                    context.Clients.All.dispatch(response);
                    break;
                case Audience.Caller:
                    context.Clients.Client(ConnectionId).dispatch(response);
                    break;
                default:
                    throw new Exception("Unknown Audience");
            }
        }
    }
}