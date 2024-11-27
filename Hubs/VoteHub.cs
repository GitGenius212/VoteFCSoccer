using Microsoft.AspNetCore.SignalR;
namespace VoteFCSoccer.Hubs
{
    public class VoteHub : Hub
    {
        public async Task SendVoteHub()
        {
        await Clients.All.SendAsync("VoteChange");
        }
    }
}