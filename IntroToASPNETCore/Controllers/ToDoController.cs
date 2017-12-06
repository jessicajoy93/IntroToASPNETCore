using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;
using IntroToASPNETCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntroToASPNETCore.Controllers
{
    public class ToDoController : Controller
    {
        // this is just a private variable to use in the controller
        private readonly ITodoItemService _todoItemService;

        // this is the constructor of the controller, it is the first thing that runs when the class is called. We are passing all the fake data from the service to the private variable.
        public ToDoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            var toDoItems = await _todoItemService.GetIncompleteItemsAsync();

            // Put items into a model
            var model = new ToDoViewModel
            {
                Items = toDoItems
            };

            // Pass the view to a model and render
            return View(model);
        }

        public async Task<IActionResult> AddItem(NewTodoItem newItem)
        {
            if (!ModelState.IsValid) //if the model returns an error
            {
                //do stuff
                return BadRequest(ModelState);
            }
            //check if the adding is successful (we still need to add AddItemAsync as it throws an error)
            bool IsSuccessful = await _todoItemService.AddItemAsync(newItem);
            if (!IsSuccessful) //if it fails
            {
                return BadRequest(new { error = "Could not add item" });
            }
            //otherwise, if it works return OK result
            return Ok();
        }
    }
}