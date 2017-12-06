using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Data;
using IntroToASPNETCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroToASPNETCore.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ToDoContext _context;

        //injects in the ToDoContext class, and passes the data to the _context
        public TodoItemService(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            //return all the items where IsDone - the boolean - is unticked
            var items = await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
            return items;
        }
    }
}
