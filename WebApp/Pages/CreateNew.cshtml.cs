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
        Classlibrary.TodoHandler NewTask = new Classlibrary.TodoHandler();
        
        public void OnGet(string title, DateTime deadLine, Classlibrary.Task.TaskType TaskType, Classlibrary.Task.Priority priority, string description)
        {
            Convert.ToInt32(deadLine);
            Classlibrary.Task task = new Classlibrary.Task(title, deadLine, TaskType, priority, description);
            NewTask.AddItem(task);
        }
    }
}