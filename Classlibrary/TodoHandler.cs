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

        public Task GetTask(ListType source, int taskIndex) {
            return _taskList[(int)source][taskIndex];
        }

        public List<Task> GetTasks(ListType firstType) {
            var todoResult = (
                from t in _taskList[(int)ListType.Todo]
                orderby (int)t.TaskPriority descending
                select t
            ).ToList();
            
            var doingResult = (
                from t in _taskList[(int)ListType.Doing]
                orderby (int)t.TaskPriority descending
                select t
            ).ToList();

            List<Task> result = (firstType == ListType.Todo) 
                ? todoResult.Union(doingResult).ToList() : doingResult.Union(todoResult).ToList();
            return result;
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

        public void MoveTask(int taskIndex, ListType source, ListType target) {
            throw new NotImplementedException();
        }
    }
}