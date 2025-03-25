using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamNorthStar_TaskTrackerApp.Models;

namespace TeamNorthStar_TaskTrackerApp.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {

        private DateTime _selectedDueDate = DateTime.Now.AddDays(1);

        public DateTime SelectedDueDate
        {
            get { return _selectedDueDate; }
            set
            {
                _selectedDueDate = value;
                OnPropertyChanged(nameof(SelectedDueDate));
            }
        }

        private ObservableCollection<Models.Task> _tasks;
        public ObservableCollection<Models.Task> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Models.Task>();
        }

        public void AddTask(Models.Task task)
        {
            Tasks.Add(task);
        }

        public void MarkTaskAsCompleted(Models.Task task)
        {
            task.IsCompleted = true;
            OnPropertyChanged(nameof(Tasks));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}









