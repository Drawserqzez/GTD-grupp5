using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Classlibrary;

namespace WebApp.Pages
{
    
    public class SearchTaskModel : PageModel
    {   
        Classlibrary.TodoHandler ToDoSearch = new Classlibrary.TodoHandler();
       
        
        public void OnGet(string searchTerm)
        {
           ToDoSearch.SearchTasks(searchTerm);
          
        }
    }
}