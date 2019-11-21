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
        private string _description;

        public string Title { get { return _title; }}
        public Priority TaskPriority { get { return _priority; }}
        public TaskType Type { get { return _type; }}

        public Task() {

        }

        public Task(string title) {
            _title = title;
        }

        public Task(string title, int deadline, TaskType type, Priority prio, string description) {
            _title = title;
            _dateAdded = DateTime.Now;
            _deadline = _dateAdded.AddDays(deadline);
            _type = type;
            _priority = prio;
            _description = description;
        }

        public override string ToString() {
            string s = _title +
                "\nDate added: " + _dateAdded.ToOADate().ToString() +
                "\nDeadline: " + _deadline.ToOADate().ToString() +
                "\nType: " + _type.ToString() + 
                "\nPriority: " + _priority.ToString() + 
                "\nDescription: " +
                "\n" + _description;
            return s;
        }
    }
}
