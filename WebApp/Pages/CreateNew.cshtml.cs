using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Classlibrary;

namespace WebApp.Pages
{
    public class CreateNewModel : PageModel
    {
               
        public void OnGet()
        {   

        }
        public void OnPost(string title, DateTime deadLine, Classlibrary.Task.TaskType TaskType, 
                            Classlibrary.Task.Priority priority)
        {
            Classlibrary.Task itemToAdd = new Classlibrary.Task(title, deadLine, TaskType, priority);
                Startup.todoHandler.AddItem(itemToAdd);
        }
    }
}