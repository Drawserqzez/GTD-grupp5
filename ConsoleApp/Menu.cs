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
                        SearchTask();
                        System.Console.WriteLine("Press any button to continue");
                        Console.ReadKey();
                        break;

                    case (int)mainMenuItems.SortByList:
                        SortByList();
                        System.Console.WriteLine("Press any button to continue");
                        Console.ReadKey();
                        break;

                    case (int)mainMenuItems.SortByAttribute:
                        SortByAttribute();
                        System.Console.WriteLine("Press any button to continue");
                        Console.ReadKey();
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
                    foreach (Task task in todoHandler.GetTasks(TodoHandler.ListType.Todo))
                    {
                        System.Console.WriteLine(task.ToString() +
                         "\n-----------------------------------------------\n");
                    }
                    break;

                case (int)sortMenuItems.Doing:
                    foreach (Task task in todoHandler.GetTasks(TodoHandler.ListType.Doing))
                    {
                        System.Console.WriteLine(task.ToString() +
                         "\n-----------------------------------------------\n");
                    }
                    break;

                case (int)sortMenuItems.Done:
                    foreach (Task task in todoHandler.GetTasks(TodoHandler.ListType.Done))
                    {
                        System.Console.WriteLine(task.ToString() +
                         "\n-----------------------------------------------\n");
                    }
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
                    foreach (Task task in todoHandler.GetTasks(false))
                    {
                        System.Console.WriteLine(task.ToString() +
                         "\n-----------------------------------------------\n");
                    }
                    break;

                case (int)AttributeMenuItems.Prio:
                    foreach (Task task in todoHandler.GetTasks(true))
                    {
                        System.Console.WriteLine(task.ToString() +
                         "\n-----------------------------------------------\n");
                    }
                    break;

                default:
                    break;
            }
        }

        private void SearchTask()
        {
            Console.Clear();

            string userInput;
            List<Task> searchedTasks = new List<Task>();
            System.Console.WriteLine("Type in what task you are searching for");
            userInput = Console.ReadLine();
            searchedTasks = todoHandler.SearchTasks(userInput);
            Console.Clear();

            foreach (Task task in searchedTasks)
            {
                System.Console.WriteLine(task.ToString() +
                 "\n-----------------------------------------------\n");
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

            Console.Clear();
            System.Console.WriteLine("How many days do you want to work on the task?");
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