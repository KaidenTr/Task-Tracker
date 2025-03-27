//Task.cs
using System;

namespace TeamNorthStar_TaskTrackerApp.Models
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

    public abstract class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = TaskStatus.NotStarted; // Default status
        }

        public abstract string GetTaskDetails();
    }

    public class PersonalTask : Task
    {
        public string Priority { get; set; }

        public PersonalTask(string title, string description, DateTime dueDate, string priority)
            : base(title, description, dueDate)
        {
            Priority = priority;
        }

        public override string GetTaskDetails()
        {
            return $"{Title} (Personal) - {Description}, Due: {DueDate.ToShortDateString()}, " +
                   $"Priority: {Priority}, Status: {Status}";
        }
    }

    public class WorkTask : Task
    {
        public string AssignedTo { get; set; }

        public WorkTask(string title, string description, DateTime dueDate, string assignedTo)
            : base(title, description, dueDate)
        {
            AssignedTo = assignedTo;
        }

        public override string GetTaskDetails()
        {
            return $"{Title} (Work) - {Description}, Due: {DueDate.ToShortDateString()}, " +
                   $"Assigned To: {AssignedTo}, Status: {Status}";
        }
    }
}


