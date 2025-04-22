//MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32; // For file dialogs
using TeamNorthStar_TaskTrackerApp.Models;
using TeamNorthStar_TaskTrackerApp.ViewModels;

namespace TeamNorthStar_TaskTrackerApp
{
    public partial class MainWindow : Window
    {
        public TaskViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new TaskViewModel();
            DataContext = ViewModel;
        }

        // Handle Add Task Button Click
        private void OnAddTaskButtonClick(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string description = DescriptionInput.Text;
            DateTime dueDate = DueDatePicker.SelectedDate ?? DateTime.Now.AddDays(1);
            string status = (StatusDropdown.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                var task = new PersonalTask(title, description, dueDate, "Medium")
                {
                    Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), status)
                };
                ViewModel.AddTask(task);

                // Reset input fields
                TitleInput.Text = "Enter task title...";
                DescriptionInput.Text = "Enter task description...";
                TitleInput.Foreground = System.Windows.Media.Brushes.Gray;
                DescriptionInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
            else
            {
                MessageBox.Show("Please fill out all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Placeholder clear when focused
        private void ClearPlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Enter task title..." || textBox.Text == "Enter task description...")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Placeholder set when unfocused
        private void SetPlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "TitleInput")
                {
                    textBox.Text = "Enter task title...";
                    textBox.Foreground = System.Windows.Media.Brushes.Gray;
                }
                else if (textBox.Name == "DescriptionInput")
                {
                    textBox.Text = "Enter task description...";
                    textBox.Foreground = System.Windows.Media.Brushes.Gray;
                }
            }
        }

        // Handle status change in the ListView
        private void OnStatusChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.DataContext is Task task)
            {
                TaskStatus newStatus = (TaskStatus)comboBox.SelectedItem;
                task.Status = newStatus;

                // Notify ViewModel about the change
                ViewModel.UpdateTaskStatus(task, newStatus);
            }
        }

        // Handle Export Button Click
        private void OnExportButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                DefaultExt = "json",
                FileName = "Tasks.json"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                ViewModel.ExportTasks(saveFileDialog.FileName);
                MessageBox.Show("Tasks exported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Handle Import Button Click
        private void OnImportButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                DefaultExt = "json"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ViewModel.ImportTasks(openFileDialog.FileName);
                MessageBox.Show("Tasks imported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}



