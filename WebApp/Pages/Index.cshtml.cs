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
       public List<string> TestToDo = new List<string>();
       public List<string> TestDoing = new List<string>();
       public List<string> TestDone = new List<string>();

       
       public List<Classlibrary.Task> taskList;
       public Classlibrary.Task task;
        public void OnGet()
        {
           taskList = Startup.todoHandler.GetTasks();
        //    task = taskList[0];
        //    task. 
        }
        

        public void doingMove() 
        {
            
        }

       
    }
    
}
