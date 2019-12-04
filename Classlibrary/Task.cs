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
        public DateTime DateAdded { get { return _dateAdded; }}
        public DateTime Deadline { get { return _deadline; }}
        public Priority TaskPriority { get { return _priority; }}
        public TaskType Type { get { return _type; }}

        public Task() {

        }

        public Task(string title) {
            _title = title;
        }

        public Task(string title, int deadline, TaskType type, Priority prio) {
            _title = title;
            _dateAdded = DateTime.Now;
            _deadline = _dateAdded.AddDays(deadline);
            _type = type;
            _priority = prio;
        }

        public Task(string title, DateTime deadline, TaskType type, Priority prio) {
            _title = title;
            _dateAdded = DateTime.Now;
            _deadline = deadline;
            _type = type;
            _priority = prio;
        }
        
        public override string ToString() {
            string s = _title +
                "\nDate added: " + _dateAdded.ToString() +
                "\nDeadline: " + _deadline.ToString() +
                "\nType: " + _type.ToString() + 
                "\nPriority: " + _priority.ToString();
            return s;
        }
    }
}
