using System;
using System.Collections.Generic;
using System.Linq;

namespace Classlibrary {
    public class TodoHandler {
        public enum ListType { Todo, Doing, Done }
        private List<List<Task>> _taskList;

        public TodoHandler() {
            _taskList = new List<List<Task>>();      
        }

        public void AddItem(Task itemToAdd) {
            _taskList[(int)ListType.Todo].Add(itemToAdd);
        }

        public List<Task> SearchTasks(string searchTerm) {
            var todoResults = 
                from t in 
                    _taskList[(int)ListType.Todo].Union(_taskList[(int)ListType.Doing]).Union(_taskList[(int)ListType.Done])                    
                where t.Title.Contains(searchTerm)
                select t;
            return todoResults.ToList();
        }

        private Task GetTask(ListType source, int taskIndex) {
            return _taskList[(int)source][taskIndex];
        }

        public List<Task> GetTasks() {
            return _taskList[(int)ListType.Todo].Union(_taskList[(int)ListType.Doing]).Union(_taskList[(int)ListType.Done]).ToList();
        }

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

        public void MoveTask(int taskIndex, ListType source) {
            int newListIndex = (source == ListType.Done) ? (int)source - 1 : (int)source + 1;
            Task taskToMove = GetTask(source, taskIndex);
            _taskList[(int)source].Remove(taskToMove);
            _taskList[newListIndex].Add(taskToMove);
        }
    }
}