using Microsoft.AspNetCore.SignalR;

public class StatusHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        // Broadcast to Everyone
        await Clients.All.SendAsync("Receive Message", user, message);
    }
}