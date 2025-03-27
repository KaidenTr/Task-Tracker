//MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;
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

                TitleInput.Text = "Enter task title...";
                DescriptionInput.Text = "Enter task description...";
            }
            else
            {
                MessageBox.Show("Please fill out all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearPlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Enter task title..." || textBox.Text == "Enter task description...")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void SetPlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "TitleInput")
                    textBox.Text = "Enter task title...";
                else if (textBox.Name == "DescriptionInput")
                    textBox.Text = "Enter task description...";

                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}

