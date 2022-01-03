using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace MvcApplication5
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string groupName)
        {
            // Call the addNewMessageToPage method to update clients.
            // Clients.All.addNewMessageToPage(name, message);
            Clients.Group(groupName).addNewMessageToPage(name, message);
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.Add(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}