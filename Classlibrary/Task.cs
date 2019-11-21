using System;

namespace Classlibrary
{
    public class Task
    {
        public enum TaskType { Work, Home, Children, Freetime }
        public enum Priority { Whenever, Low, Medium, High, Immediately }

        private string _title;
        private DateTime _dateAdded;
        private DateTime _deadline;
        private TaskType _type;
        private Priority _priority; 

        public string Title { get { return _title; }}
        public Priority TaskPriority { get { return _priority; }}
        public TaskType Type { get { return _type; }}

        public Task() {

        }

        public Task(string title, int deadline, TaskType type, Priority prio) {
            _title = title;
            _dateAdded = DateTime.Now;
            _deadline = _dateAdded.AddDays(deadline);
            _type = type;
            _priority = prio;
        }
    }
}
