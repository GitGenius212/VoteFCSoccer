using Microsoft.AspNetCore.SignalR;
namespace VoteFCSoccer.Hubs
{
    public class EquipeHub : Hub
    {
        public async Task SendMessage()
        {
        await Clients.All.SendAsync("EquipeChange");
        }
    }
}