using Microsoft.AspNetCore.SignalR;
namespace VoteFCSoccer.Hubs
{
    public class VoteHub : Hub
    {
        public async Task SendMessage()
        {
        await Clients.All.SendAsync("VoteChange");
        }
    }
}