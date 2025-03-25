using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
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
            ViewModel = (TaskViewModel)DataContext;
        }

        private void OnAddTaskButtonClick(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string description = DescriptionInput.Text;
            DateTime dueDate = DueDatePicker.SelectedDate ?? DateTime.Now.AddDays(1);
            string priority = (PriorityDropdown.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Medium";

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                var task = new PersonalTask(title, description, dueDate, priority);
                ViewModel.AddTask(task);

                TitleInput.Text = "Enter task title...";
                TitleInput.Foreground = System.Windows.Media.Brushes.Gray;

                DescriptionInput.Text = "Enter task description...";
                DescriptionInput.Foreground = System.Windows.Media.Brushes.Gray;

                DueDatePicker.SelectedDate = DateTime.Now.AddDays(1);
                PriorityDropdown.SelectedIndex = 1; 
            }
            else
            {
                MessageBox.Show("Please enter a valid title, description, and due date!",
                                "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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

















