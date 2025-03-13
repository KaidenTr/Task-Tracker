namespace TaskTracker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnCompleteTask;
        private System.Windows.Forms.ListBox lstTasks;

        private void InitializeComponent()
        {
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(20, 20);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(200, 20);
            this.txtTaskName.TabIndex = 0;
            this.txtTaskName.TextChanged += new System.EventHandler(this.txtTaskName_TextChanged);
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(20, 50);
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(200, 20);
            this.txtTaskDescription.TabIndex = 1;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(20, 80);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDueDate.TabIndex = 2;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(20, 110);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.Click += new System.EventHandler(this.BtnAddTask_Click);
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Location = new System.Drawing.Point(110, 110);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(100, 23);
            this.btnCompleteTask.TabIndex = 4;
            this.btnCompleteTask.Text = "Complete Task";
            this.btnCompleteTask.Click += new System.EventHandler(this.BtnCompleteTask_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.Location = new System.Drawing.Point(20, 150);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(400, 199);
            this.lstTasks.TabIndex = 5;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.txtTaskDescription);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnCompleteTask);
            this.Controls.Add(this.lstTasks);
            this.Name = "Form1";
            this.Text = "Task Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
