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
        public bool sortAt {get; set;}

        public void OnGet(int SortNum)
        {
            if (SortNum == 1)
                {sortAt = true;}
            else if (SortNum == 0)
                {sortAt = false;}
            taskList = Startup.todoHandler.GetTasks(sortAt);
        }
        

        public void doingMove() 
        {
           // string majs = Classlibrary.TodoHandler._taskList;
           // string majs = Classlibrary.Task.
                 }

       
    }
    
}
