using Microsoft.AspNetCore.SignalR;
using ServiceStack;


namespace ProvaDueDatabase.Hubs
{

    public class ChatHub : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("Join");
        }
        public async Task SendMessageToGroup(string Group, string message, string figura, int count, string rispostaLibera, int inpEspressione)
        {
            await Clients.OthersInGroup(Group).SendAsync("ReceiveMessage", message, figura, count, rispostaLibera, inpEspressione); 
        }

        public async Task SendRestartMessage(string Group, string idFigura)
        {
            await Clients.OthersInGroup(Group).SendAsync("RestartMessage", idFigura);
        }

    }
}

