using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace IntroToASPNETCore.Models
{
    public class Model : DbContext
    {
        public DbSet<TodoItem> Items { get; set; }
    }

    public class Item
    {
        public string Title { get; set; }
        public string DueAt { get; set; }
    }
}
