using System;

namespace ConsoleApp
{
    class Menu
    {
        enum menuItems
        {
            toDo = 0,
            doing = 1,
            done = 2
        }
        public int DisplayMenu(string[] menuOptions, string header)
        {
            int currentIndex = 0;
            ConsoleKey keyPress;
            string selectionArrow = "-> ";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                foreach (string s in menuOptions)
                {
                    string finalOption = "";
                    if (Array.IndexOf(menuOptions, s) == currentIndex)
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
                    currentIndex = (currentIndex == 0) ? menuOptions.Length - 1 : currentIndex - 1;
                }
                else if (keyPress == ConsoleKey.DownArrow)
                {
                    currentIndex = (currentIndex == menuOptions.Length - 1) ? 0 : currentIndex + 1;
                }
                else if (keyPress == ConsoleKey.Enter)
                {
                    MenuOptions(currentIndex);
                    return currentIndex;
                }
            }
        }

        private void MenuOptions(int returnIndex)
        {
            switch (returnIndex)
            {
                case (int)menuItems.toDo:
                    System.Console.WriteLine("TODO");
                    break;

                case (int)menuItems.doing:
                    System.Console.WriteLine("DOING");
                    break;

                case (int)menuItems.done:
                    System.Console.WriteLine("DONE");
                    break;

                default:
                    break;
            }
        }
    }
}