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

        // public void OnGet() {

        // }

        public void OnGet(string searchTerm = "")
        {
            // Victor löste efter trubbel, kolla default parameter.
            // Victors lösning gav error vid null-sökning. Ändrade om.
            
            if (String.IsNullOrEmpty(searchTerm)) {
                Results = new List<Classlibrary.Task>();
            }
            else {

            Results = Startup.todoHandler.SearchTasks(searchTerm);
            }
        }

       // [HttpGet]
      //  public void OnGet(string searchTerm) {

         //  Results = Startup.todoHandler.SearchTasks(searchTerm);   
       // }
       // public void OnPost()
        
    }
}