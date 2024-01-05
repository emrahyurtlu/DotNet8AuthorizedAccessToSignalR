using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Net8Identity.Hubs;

[Authorize]
public class MathHub: Hub
{
    public async Task GetSquareRootAsync(string value)
    {
        await Clients.All.SendAsync("ReceiveRootOfNumber", Math.Sqrt(int.Parse(value)));
    }
}
