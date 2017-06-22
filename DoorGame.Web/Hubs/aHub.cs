using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace DoorGame.Web.Hubs
{
    public class aHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}