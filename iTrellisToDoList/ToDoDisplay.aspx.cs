using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTrellisToDoList
{
    public partial class ToDoDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //When page is opened for first time, create a Session TaskRepository in memory
            if (!Page.IsPostBack)
            {
                TaskRepository repo = new TaskRepository();
                Session["Repo"] = repo;
            }
        }

        //Fill grids with sample data
        protected void LoadTestData_Click(object sender, EventArgs e)
        {
            TaskRepository repo = new TaskRepository();
            repo.AddTask(new Task("Go to the grocery store", "Buy milk, eggs, and French bread.", DateTime.Now.AddDays(2)));
            repo.AddTask(new Task("Attend sister's wedding", "In Hawaii. Must wear black.", new DateTime(2015, 10, 31)));
            repo.AddTask(new Task("Learn guitar", "Especially Wonderwall - popular at parties!"));
            repo.AddTask(new Task("Finish homework", "50 page essay on candles as metaphor for English orphan children in Dickens' Oliver Twist", new DateTime(2015, 01, 01)));
            Task sampleCompletedTask = new Task("Be cool", "Simple!");
            sampleCompletedTask.IsCompleted = true;
            repo.AddTask(sampleCompletedTask);
            Session["Repo"] = repo; //Overwrite any existing tasks
            FormatDataGrids();
        }

        //Formats DueDate column in each DataGridRow to a more readable short-form DateTime and changes the background of any overdue tasks to red
        private void FormatDataGrids()
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            PendingGridView.DataSource = repo.GetPendingTasks();
            CompletedGridView.DataSource = repo.GetCompletedTasks();
            Page.DataBind();

            foreach (GridViewRow row in PendingGridView.Rows)
            {
                //If no DueDate was entered, do not display default DateTime; instead, show "N/A"
                DateTime rowDate = DateTime.Parse(row.Cells[2].Text);
                if (rowDate == default(DateTime))
                {
                    row.Cells[2].Text = "N/A";
                }
                //Change row background to red if the DueDate is past due
                else if (rowDate < DateTime.Today)
                {
                    row.BackColor = System.Drawing.Color.Red;
                    row.Cells[2].Text = rowDate.ToShortDateString();
                }
                else
                {
                    row.Cells[2].Text = rowDate.ToShortDateString();
                }
            }

            //Same as above, but since no completed task can be overdue, do not include the DueDate check
            foreach (GridViewRow row in CompletedGridView.Rows)
            {
                DateTime rowDate = DateTime.Parse(row.Cells[2].Text);
                if (rowDate == default(DateTime))
                {
                    row.Cells[2].Text = "N/A";
                }
                else
                {
                    row.Cells[2].Text = rowDate.ToShortDateString();
                }
            }
        }

        //Mark selected tasks as completed
        protected void CompleteButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            //Workaround for not being able to get the row DataItems
            List<Task> tempList = repo.GetPendingTasks();
            List<int> idList = new List<int>();

            //Find checked checkboxes and get their row index
            foreach (GridViewRow row in PendingGridView.Rows)
            {
                var checkBox = (CheckBox)row.Cells[0].FindControl("PendingTaskCheckBox");
                if (checkBox.Checked)
                {
                    //Use the row index to get the ID of the Task that would normally have been in that row (button click eliminated that data)
                    idList.Add(tempList[row.RowIndex].ID);
                }
            }

            //Use the list of Task IDs to mark each Task with matching IDs as completed
            if (idList.Count > 0)
            {
                foreach (var id in idList)
                    repo.CompleteTask(id);
            }

            FormatDataGrids();
        }

        //Delete selected Tasks from the Pending list of tasks
        protected void PendingDeleteButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            //Workaround for not being able to get the row DataItems
            List<Task> tempList = repo.GetPendingTasks();
            List<int> idList = new List<int>();

            //Find checked checkboxes and get their row index
            foreach (GridViewRow row in PendingGridView.Rows)
            {
                var checkBox = (CheckBox)row.Cells[0].FindControl("PendingTaskCheckBox");
                if (checkBox.Checked)
                {
                    //Use the row index to get the ID of the Task that would normally have been in that row (button click eliminated that data)
                    idList.Add(tempList[row.RowIndex].ID);
                }
            }

            //Use the list of Task IDs to delete each Task with matching ID
            if (idList.Count > 0)
            {
                foreach (var id in idList)
                    repo.RemoveTask(id);
            }

            FormatDataGrids();
        }

        //Delete selected Tasks from the Completed list of tasks
        protected void CompletedDeleteButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            //Workaround for not being able to get the row DataItems
            List<Task> tempList = repo.GetCompletedTasks();
            List<int> idList = new List<int>();

            //Find checked checkboxes and get their row index
            foreach (GridViewRow row in CompletedGridView.Rows)
            {
                var checkBox = (CheckBox)row.Cells[0].FindControl("CompletedTaskCheckBox");
                if (checkBox.Checked)
                {
                    //Use the row index to get the ID of the Task that would normally have been in that row (button click eliminated that data)
                    idList.Add(tempList[row.RowIndex].ID);
                }
            }

            //Use the list of Task IDs to delete each Task with matching ID
            if (idList.Count > 0)
            {
                foreach (var id in idList)
                    repo.RemoveTask(id);
            }

            FormatDataGrids();
        }

        //Add a new task to the Repo using user-entered data
        protected void FinalizeAddButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];

            try
            {
                if (NoDueDateCheckBox.Checked) //Add task without a DueDate
                {
                    repo.AddTask(new Task(TitleTextBox.Text, DetailsTextBox.Text));
                    FormatDataGrids();

                    //Return view to Tasks list
                    ViewTasksPanel.Visible = true;
                    AddTaskPanel.Visible = false;
                }
                else //Add task with a DueDate
                {
                    repo.AddTask(new Task(TitleTextBox.Text, DetailsTextBox.Text, DueDateCalendar.SelectedDate));
                    FormatDataGrids();

                    //Return view to Tasks list
                    ViewTasksPanel.Visible = true;
                    AddTaskPanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //Should only get here if data validation has failed
                ErrorLabel.Visible = true;
                ErrorLabel.Text = ex.Message;
            }
        }

        //Show the view for adding a task
        protected void AddButton_Click(object sender, EventArgs e)
        {
            ViewTasksPanel.Visible = false;
            AddTaskPanel.Visible = true;

            //Reset values
            ErrorLabel.Visible = false;
            TitleTextBox.Text = "";
            DetailsTextBox.Text = "";
            DueDateCalendar.SelectedDate = DateTime.Today;
        }

        //If "N/A" is chosen when adding a task, hide the calendar because it is unnecessary
        protected void NoDueDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NoDueDateCheckBox.Checked)
                DueDateCalendar.Visible = false;
            else
                DueDateCalendar.Visible = true;
        }
    }
}