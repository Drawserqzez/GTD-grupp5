using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Classlibrary;


namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {       
        public List<Classlibrary.Task> taskList;
        public Classlibrary.Task task;
       // public List<Classlibrary.TodoHandler.ListType> takslisto;
        public List<Classlibrary.Task> moveTask;
        public void OnGet(int SortNum, int State)
        {
            bool sortByPriority;
            
            if (SortNum > 0)
            {
                if (SortNum == 1)
                {
                    sortByPriority = true;
                    taskList = Startup.todoHandler.GetTasks(sortByPriority);
                }
                else if (SortNum == 2)
                {
                    sortByPriority = false;
                    taskList = Startup.todoHandler.GetTasks(sortByPriority);
                }
            }
            else
            {
                taskList = Startup.todoHandler.GetTasks();
            }
            if (State > -1)
            {
                if (State == 0)
                {
                    taskList = Startup.todoHandler.GetTasks((TodoHandler.ListType)State);
                }
                else if (State == 1)
                {
                    taskList = Startup.todoHandler.GetTasks((TodoHandler.ListType)State);
                }
                else if (State == 2)
                {
                    taskList = Startup.todoHandler.GetTasks((TodoHandler.ListType)State);
                }
            }
        }
        public void OnPost(int State, int move) 
        {
           Startup.todoHandler.MoveTask(move, (TodoHandler.ListType)State);
        }
    }
}
