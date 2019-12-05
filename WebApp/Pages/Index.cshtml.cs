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
        public void OnGet(int SortNum, int State)
        {
            bool sortByPriority;
            taskList = Startup.todoHandler.GetTasks();
            if (SortNum > 0)
            // Choice of sort, either priority or type.
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
            // Gets all tasks from a specified list
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
        public void OnPost(int State, string move) 
        {
            // Checked radiobutton sends title with move. 
            int moveTask = Startup.todoHandler.GetTasks().FindIndex(p => p.Title == move); 
            // Use of gettasks to find the index of the checked task  and gives it to moveTask
            Startup.todoHandler.MoveTask(moveTask, (TodoHandler.ListType)Startup.todoHandler.GetListType(moveTask));
            // Send index of task to MoveTask.
            int SortNum = 0;
            OnGet(SortNum, State);
        }
    }
}
