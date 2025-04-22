//TaskViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TeamNorthStar_TaskTrackerApp.Models;

namespace TeamNorthStar_TaskTrackerApp.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> Tasks { get; set; }
        private Task _selectedTask;

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>();
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void UpdateTaskStatus(Task task, TaskStatus newStatus)
        {
            task.Status = newStatus;
            OnPropertyChanged(nameof(Tasks)); // Notify UI to refresh the task list
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


