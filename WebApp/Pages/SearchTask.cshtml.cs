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
        public List<Classlibrary.Task> Results;


        public void OnGet(string searchTerm)
        {
            
            
            if (String.IsNullOrEmpty(searchTerm))
            // If the value of searchTerm is null nothing gets printed out.
            // Instead of having the default parameters Viktor added.
            // Added because error when search was empty.
            {
                Results = new List<Classlibrary.Task>();
            }
            else 
            // Sends search to the search method.
            {
            Results = Startup.todoHandler.SearchTasks(searchTerm);
            }
        }
        public void Onpost()
        {
            
        }
    }
}