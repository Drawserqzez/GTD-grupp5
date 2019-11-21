using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Menu
    {
        enum mainMenuItems
        {
            CreateTask,
            SearchTasks,
            SortByList,
            SortByAttribute,
            Notes,
            Quit
        }
        enum sortMenuItems
        {
            Todo,
            Doing,
            Done
        }
        public int DisplayMenu(List<string> menuThings, string header)
        {
            int currentIndex = 0;
            ConsoleKey keyPress;
            string selectionArrow = "-> ";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                foreach (string s in menuThings)
                {
                    string finalOption = "";
                    if (menuThings.IndexOf(s) == currentIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        finalOption += selectionArrow;
                    }
                    else
                    {
                        finalOption += "   ";
                    }
                    finalOption += s;
                    Console.WriteLine(finalOption);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                keyPress = Console.ReadKey(true).Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentIndex = (currentIndex == 0) ? menuThings.Count - 1 : currentIndex - 1;
                }
                else if (keyPress == ConsoleKey.DownArrow)
                {
                    currentIndex = (currentIndex == menuThings.Count - 1) ? 0 : currentIndex + 1;
                }
                else if (keyPress == ConsoleKey.Enter)
                {
                    return currentIndex;
                }
            }
        }

        public void MainMenuOptions()
        {
            List<string> mainMenuOptions = AddEnumItems.CreateUpperCase(typeof(mainMenuItems));
            int returnIndex = DisplayMenu(mainMenuOptions, "Main Menu");
            switch (returnIndex)
            {
                case (int)mainMenuItems.CreateTask:
                    System.Console.WriteLine("Create Task");
                    break;

                case (int)mainMenuItems.SearchTasks:
                    System.Console.WriteLine("Search Task");
                    break;

                case (int)mainMenuItems.SortByList:
                    SortByList();
                    break;

                case (int)mainMenuItems.SortByAttribute:
                    System.Console.WriteLine("Sort by attribute");
                    break;

                case (int)mainMenuItems.Notes:
                    System.Console.WriteLine("Notes");
                    break;

                case (int)mainMenuItems.Quit:
                    System.Console.WriteLine("Quit");
                    return;

                default:
                    break;
            }
        }

        private void SortByList()
        {
            List<string> sortOptionsMenu = AddEnumItems.CreateUpperCase(typeof(sortMenuItems));
            int returnIndex = DisplayMenu(sortOptionsMenu, "Sort Menu");
            switch (returnIndex)
            {
                case (int)sortMenuItems.Todo:
                    System.Console.WriteLine("TODO");
                    break;

                case (int)sortMenuItems.Doing:
                    System.Console.WriteLine("DOING");
                    break;

                case (int)sortMenuItems.Done:
                    System.Console.WriteLine("DONE");
                    break;
                default:
                    break;
            }
        }
    }
}