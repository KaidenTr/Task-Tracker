using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskTracker
{
    public partial class Form1 : Form
    {
        private List<Task> taskList = new List<Task>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            // Create a new task
            Task newTask = new Task
            {
                TaskID = taskList.Count + 1,
                Name = txtTaskName.Text,
                Description = txtTaskDescription.Text,
                DueDate = dtpDueDate.Value,
                IsCompleted = false
            };

            // Add the task to the list
            taskList.Add(newTask);

            // Display the task in the ListBox
            lstTasks.Items.Add($"ID: {newTask.TaskID}, Name: {newTask.Name}, Due: {newTask.DueDate.ToShortDateString()}");

            // Clear input fields
            txtTaskName.Clear();
            txtTaskDescription.Clear();
        }

        private void BtnCompleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0)
            {
                // Find the selected task
                Task selectedTask = taskList[lstTasks.SelectedIndex];
                selectedTask.MarkAsCompleted();

                // Update the ListBox
                lstTasks.Items[lstTasks.SelectedIndex] = $"ID: {selectedTask.TaskID}, Name: {selectedTask.Name} (Completed)";
            }
            else
            {
                MessageBox.Show("Please select a task to complete.");
            }
        }

        private void txtTaskName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
