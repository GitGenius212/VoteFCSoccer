using Microsoft.AspNetCore.SignalR;
namespace VoteFCSoccer.Hubs
{
    public class CandidatHub : Hub
    {
        public async Task SendCandidatHub()
        {
        await Clients.All.SendAsync("CandidatChange");
        }
    }
}