using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs;

public class ProductHub : Hub
{

    public async Task LoadCategory()
    {
        await Clients.All.SendAsync("LoadProductsOnCategory");
    }

    public async Task AddProductCategory()
    {
        await Clients.All.SendAsync("LoadProductsOnCategory");
    }

    // public override async Task OnConnectedAsync()
    // {
    //     await base.OnConnectedAsync();
    //     //await Clients.All.SendAsync("LoadCategory");
    // }

    // public override async Task OnDisconnectedAsync(Exception? ex)
    // {
    //     Console.WriteLine($"disconnectd client-id: {Context.ConnectionId}");

    //     await base.OnDisconnectedAsync(ex);
    // }
}
