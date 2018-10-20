using FilipTest.Models;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace FilipTest.Hubs
{
    public class BooksHub : Hub
    {
        public async Task GetLast()
        {
            await Clients.All.SendAsync("raiseLast", Book.Data.Last());
        }

        public async Task GetAll()
        {
            await Clients.All.SendAsync("raiseAll", Book.Data);
        }

        public async Task GetNoApi()
        {
            var book = new Book {
                Author = "John Lennon",
                Title = "In his own write.",
                Price = 123.54,
                Words = 982123
            };
            await Clients.All.SendAsync("raiseLast", book);
        }

    }
}
