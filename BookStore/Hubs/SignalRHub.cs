using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BookStore.API.Hubs
{
    public class SignalRHub : Hub
    {
        public SignalRHub()
        {
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}
