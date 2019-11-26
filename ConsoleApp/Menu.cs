using System;
using System.Collections.Generic;
using Classlibrary;

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
        enum AttributeMenuItems
        {
            Type,
            Prio
        }
        private TodoHandler todoHandler = new TodoHandler();

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
            bool isOn = true;
            while (isOn)
            {
                List<string> mainMenuOptions = AddEnumItems.CreateUpperCase(typeof(mainMenuItems));
                int returnIndex = DisplayMenu(mainMenuOptions, "Main Menu");
                switch (returnIndex)
                {
                    case (int)mainMenuItems.CreateTask:
                        CreateNewTask();
                        break;

                    case (int)mainMenuItems.SearchTasks:
                        todoHandler.GetTasks();
                        break;

                    case (int)mainMenuItems.SortByList:
                        SortByList();
                        break;

                    case (int)mainMenuItems.SortByAttribute:
                        SortByAttribute();
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

        private void SortByAttribute()
        {
            List<string> sortAttributesMenu = AddEnumItems.CreateUpperCase(typeof(AttributeMenuItems));
            int returnIndex = DisplayMenu(sortAttributesMenu, "Attributes Menu");
            switch (returnIndex)
            {
                case (int)AttributeMenuItems.Type:
                    System.Console.WriteLine("Sort by type");
                    break;

                case (int)AttributeMenuItems.Prio:
                    System.Console.WriteLine("Sort by prio");
                    break;

                default:
                    break;
            }
        }

        private void CreateNewTask()
        {
            string title;
            int deadLine;
            string description;
            Task.TaskType taskType;
            Task.Priority priorityType;

            Console.Clear();
            System.Console.WriteLine("Write a title for your task");
            title = Console.ReadLine();

            //TODO: Kolla om man ska ta in en datetime istället här!
            Console.Clear();
            System.Console.WriteLine("What's your deadline for the project?");
            deadLine = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            System.Console.WriteLine("Write a short description for you task");
            description = Console.ReadLine();


            List<string> TaskTypeMenu = AddEnumItems.CreateUpperCase(typeof(Task.TaskType));
            int returnIndex = DisplayMenu(TaskTypeMenu, "Choose what type of task it is");
            switch (returnIndex)
            {
                case (int)Task.TaskType.Children:
                    System.Console.WriteLine("Children");
                    taskType = Task.TaskType.Children;
                    break;

                case (int)Task.TaskType.Freetime:
                    System.Console.WriteLine("Freetime");
                    taskType = Task.TaskType.Freetime;
                    break;

                case (int)Task.TaskType.Home:
                    System.Console.WriteLine("Home");
                    taskType = Task.TaskType.Home;
                    break;

                case (int)Task.TaskType.Work:
                    System.Console.WriteLine("Work");
                    taskType = Task.TaskType.Work;
                    break;

                default:
                    taskType = Task.TaskType.Home;
                    break;
            }

            List<string> TaskPriorityMenu = AddEnumItems.CreateUpperCase(typeof(Task.Priority));
            int returnIndexTwo = DisplayMenu(TaskPriorityMenu, "What is the priority?");
            switch (returnIndexTwo)
            {
                case (int)Task.Priority.High:
                    System.Console.WriteLine("High");
                    priorityType = Task.Priority.High;
                    break;

                case (int)Task.Priority.Immediately:
                    System.Console.WriteLine("Immediately");
                    priorityType = Task.Priority.Immediately;
                    break;

                case (int)Task.Priority.Medium:
                    System.Console.WriteLine("Medium");
                    priorityType = Task.Priority.Medium;
                    break;

                case (int)Task.Priority.Low:
                    System.Console.WriteLine("Low");
                    priorityType = Task.Priority.Low;
                    break;

                case (int)Task.Priority.Whenever:
                    System.Console.WriteLine("Whenever");
                    priorityType = Task.Priority.Whenever;
                    break;

                default:
                    priorityType = Task.Priority.Whenever;
                    break;
            }
            Task task = new Task(title, deadLine, taskType, priorityType, description);
            todoHandler.AddItem(task);
        }
    }
}