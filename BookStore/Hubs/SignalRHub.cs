using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Hubs
{
    public class SignalRHub : Hub
    {
        private List<string> _groupUserNames { get; set; }

        public SignalRHub()
        {
            _groupUserNames = new List<string>();
        }

        public async Task Send(ChatMessageView message)
        {
            await Clients.All.SendAsync("MessageReceived", message);
        }

        public async Task JoinToGroup(string name)
        {
            _groupUserNames.Add(name);

            await Clients.All.SendAsync("JoinGroup", _groupUserNames);
        }

        public async Task AddUserChat(string name)
        {
            
            await Clients.All.SendAsync("", _groupUserNames);
        }

        public async Task DeleteUserChat()
        {

            await Clients.All.SendAsync("", _groupUserNames);
        }
    }

    public class ChatMessageView
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
