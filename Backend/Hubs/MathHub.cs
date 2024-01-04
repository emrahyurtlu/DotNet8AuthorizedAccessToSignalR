using Microsoft.AspNetCore.SignalR;

namespace Net8Identity.Hubs;

public class MathHub: Hub
{
    public async Task GetSquareRootAsync(double number)
    {
        await Clients.All.SendAsync("GetRootOfNumber", Math.Sqrt(number));
    }
}
