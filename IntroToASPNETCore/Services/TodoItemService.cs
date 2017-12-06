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

        public async Task<bool> AddItemAsync(NewTodoItem newItem)
        {
            var entity = new TodoItem
            {
                Id = Guid.NewGuid(), //a random ID number
                IsDone = false, //isDone is set to false (no tick in the checkbox)
                Title = newItem.Title, //the new title goes in
                DueAt = DateTimeOffset.Now.AddDays(3) //the date is set to 3 days in the future
            };
            _context.Items.Add(entity); //add all these fields to the entity

            //save the changes to the database
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
