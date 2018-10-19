using FilipTest.Models;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace FilipTest.Hubs
{
    public class Books:Hub
    {
        // temporary
        public async Task Sample()
        {
            await Clients.All.SendAsync("raiseSample", Book.Data.Last());
        }
    }
}
