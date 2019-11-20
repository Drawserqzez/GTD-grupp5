using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] things = new string[] { "TODO", "DOING", "DONE" };
            Menu menu = new Menu();
            menu.DisplayMenu(things, "Get Things Done!");
        }
    }
}
