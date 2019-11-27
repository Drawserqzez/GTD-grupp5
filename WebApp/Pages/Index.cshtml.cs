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

        public void OnGet()
        {
            TestToDo.Add("Majs1");
            TestToDo.Add("Majs2");
            TestDoing.Add("Majs3");
            TestDoing.Add("Majs4");
            TestDone.Add("Majs5");
            TestDone.Add("Majs6");
        }
        

        public void doingMove() 
        {
            
        }

       
    }
    
}
