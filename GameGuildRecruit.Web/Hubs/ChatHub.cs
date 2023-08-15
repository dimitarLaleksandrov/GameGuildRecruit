using Microsoft.AspNetCore.SignalR;
using System.Net;

namespace GameGuildRecruit.Web.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
