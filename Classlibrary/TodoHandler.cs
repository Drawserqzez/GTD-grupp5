using System;
using System.Collections.Generic;
using System.Linq;

namespace Classlibrary {
    public class TodoHandler {
        public enum ListType { Todo, Doing, Done }
        private List<List<Task>> _taskList;

        public TodoHandler() {
            _taskList = new List<List<Task>>();
            _taskList.Add(new List<Task>());      
            _taskList.Add(new List<Task>());      
            _taskList.Add(new List<Task>());     

            this.AddItem(new Task("Förbered tacokväll", DateTime.Now.AddDays(5), Task.TaskType.Home, Task.Priority.Immediately));
            this.AddItem(new Task("Köp kaffe", 1, Task.TaskType.Work, Task.Priority.Medium));
            this.AddItem(new Task("Hämta barnen på dagis", 25, Task.TaskType.Children, Task.Priority.Low));
        }

        // AddItem adds a task to the todo-list. Can later be changed with MoveTask
        public void AddItem(Task itemToAdd) {
            _taskList[(int)ListType.Todo].Add(itemToAdd);
        }

        // LINQ query that searches the titles of the tasks and returns a list with all results.
        // If no results exists it returns a list and a task with an error-message
        public List<Task> SearchTasks(string searchTerm) {
            var todoResults = 
                from t in 
                    _taskList[(int)ListType.Todo].Union(_taskList[(int)ListType.Doing]).Union(_taskList[(int)ListType.Done])                    
                where t.Title.Contains(searchTerm)
                select t;
            return (todoResults != null) ? todoResults.ToList() : new List<Task>{ new Task("No results found") };
        }

        // Gets a task at a specific index from a specific list
        // With problems it returns an error
        private Task GetTask(int taskIndex) {
            try {
                return GetTasks()[taskIndex];
            }
            catch {
                return new Task("Error");
            }
        }

        // Returns all tasks 
        public List<Task> GetTasks() {
            return _taskList[(int)ListType.Todo].Union(_taskList[(int)ListType.Doing]).Union(_taskList[(int)ListType.Done]).ToList();
        }

        // Returns tasks from the Todo- and Doing-lists and sorts them by priority or by tasktype
        public List<Task> GetTasks(bool sortByPriority) {        
            if (sortByPriority) {
                return (
                    from t in _taskList[(int)ListType.Todo].Union(_taskList[(int)ListType.Doing])
                    orderby (int)t.TaskPriority descending
                    select t
                ).ToList();
            }
            else {
                return (
                    from t in _taskList[(int)ListType.Todo].Union(_taskList[(int)ListType.Doing])
                    orderby (int)t.Type
                    select t
                ).ToList();
            }
        }

        // Gets all tasks from a specified list
        public List<Task> GetTasks(ListType source) {
            return _taskList[(int)source];
        }

        // Moves a task from one list to the next one in
        // If the original list is the Done-list, it moves it back to Doing
        // Otherwise it moves it up one step
        // Ex Todo -> Doing -> Done -> Doing 
        public void MoveTask(int taskIndex, ListType source) {
            ListType newListType = (source == ListType.Done) ? (ListType)((int)source - 1) : (ListType)((int)source + 1);
            Task taskToMove = GetTask(taskIndex);
            _taskList[(int)source].Remove(taskToMove);
            _taskList[(int)newListType].Add(taskToMove);
        }

        private bool IsTaskInList(Task task, ListType list) {
            var check = _taskList[(int)list].FindAll(t => t == task);
            return (check != null && check.Count > 0);
        }

        public ListType GetListType(int taskIndex) {
            var taskList = GetTasks();
            var task = taskList[taskIndex];
            for (int i = 0; i < _taskList.Count; i++) {
                if (IsTaskInList(task, (ListType)i)) {
                    return (ListType)i;
                }
            }

            return ListType.Done;            
        }
    }
}