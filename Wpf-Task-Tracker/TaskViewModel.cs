//TaskViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
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

        public void ExportTasks(string filePath)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };

            var serializedTasks = JsonConvert.SerializeObject(Tasks.ToList(), settings);
            File.WriteAllText(filePath, serializedTasks);
        }

        public void ImportTasks(string filePath)
        {
            if (File.Exists(filePath))
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Converters = { new TaskJsonConverter() }
                };

                var serializedTasks = File.ReadAllText(filePath);
                var deserializedTasks = JsonConvert.DeserializeObject<ObservableCollection<Task>>(serializedTasks, settings);

                Tasks.Clear();
                foreach (var task in deserializedTasks)
                {
                    Tasks.Add(task);
                }
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}







