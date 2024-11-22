using Microsoft.AspNetCore.SignalR;
namespace VoteFCSoccer.Hubs
{
    public class LibelleVoteHub : Hub
    {
        public async Task SendMessage()
        {
        await Clients.All.SendAsync("LibelleVoteChange");
        }
    }
}