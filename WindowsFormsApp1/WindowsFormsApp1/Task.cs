using System;

namespace TaskTracker
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task() { }

        public void UpdateDetails(string newName, string newDescription, DateTime newDueDate)
        {
            Name = newName;
            Description = newDescription;
            DueDate = newDueDate;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}
