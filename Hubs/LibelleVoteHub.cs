using Microsoft.AspNetCore.SignalR;
namespace VoteFCSoccer.Hubs
{
    public class LibelleVoteHub : Hub
    {
        public async Task SendLibelleVote()
        {
        await Clients.All.SendAsync("LibelleVoteChange");
        }
    }
}