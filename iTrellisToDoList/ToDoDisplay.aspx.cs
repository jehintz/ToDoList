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
            if (!Page.IsPostBack)
            {
                TaskRepository repo = new TaskRepository();
                Session["Repo"] = repo;
                PendingGridView.DataSource = repo.GetPendingTasks();
                CompletedGridView.DataSource = repo.GetCompletedTasks();
                Page.DataBind();
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
            Session["Repo"] = repo;
            PendingGridView.DataSource = repo.GetPendingTasks();
            CompletedGridView.DataSource = repo.GetCompletedTasks();
            Page.DataBind();
            FormatDataGrids();
        }

        //Formats DueDate column data in each DataGrid to a more readable format and changes the background of any overdue tasks to red
        private void FormatDataGrids()
        {
            foreach (GridViewRow row in PendingGridView.Rows)
            {
                DateTime rowDate = DateTime.Parse(row.Cells[2].Text);
                if (rowDate == default(DateTime))
                {
                    row.Cells[2].Text = "N/A";
                }
                else if (rowDate < DateTime.Now)
                {
                    row.BackColor = System.Drawing.Color.Red;
                    row.Cells[2].Text = rowDate.ToShortDateString();
                }
                else
                {
                    row.Cells[2].Text = rowDate.ToShortDateString();
                }
            }

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

        protected void CompleteButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            List<Task> tempList = repo.GetPendingTasks();
            List<int> idList = new List<int>();

            foreach (GridViewRow row in PendingGridView.Rows)
            {
                var checkBox = (CheckBox)row.Cells[0].FindControl("PendingTaskCheckBox");
                if (checkBox.Checked)
                {
                    idList.Add(tempList[row.RowIndex].ID);
                }
            }

            if (idList.Count > 0)
            {
                foreach (var id in idList)
                    repo.CompleteTask(id);
            }

            PendingGridView.DataSource = repo.GetPendingTasks();
            CompletedGridView.DataSource = repo.GetCompletedTasks();
            Page.DataBind();
            FormatDataGrids();
        }

        protected void PendingDeleteButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            List<Task> tempList = repo.GetPendingTasks();
            List<int> idList = new List<int>();

            foreach (GridViewRow row in PendingGridView.Rows)
            {
                var checkBox = (CheckBox)row.Cells[0].FindControl("PendingTaskCheckBox");
                if (checkBox.Checked)
                {
                    idList.Add(tempList[row.RowIndex].ID);
                }
            }

            if (idList.Count > 0)
            {
                foreach (var id in idList)
                    repo.RemoveTask(id);
            }

            PendingGridView.DataSource = repo.GetPendingTasks();
            CompletedGridView.DataSource = repo.GetCompletedTasks();
            Page.DataBind();
            FormatDataGrids();
        }

        protected void CompletedDeleteButton_Click(object sender, EventArgs e)
        {
            TaskRepository repo = (TaskRepository)Session["Repo"];
            List<Task> tempList = repo.GetCompletedTasks();
            List<int> idList = new List<int>();

            foreach (GridViewRow row in CompletedGridView.Rows)
            {
                var checkBox = (CheckBox)row.Cells[0].FindControl("CompletedTaskCheckBox");
                if (checkBox.Checked)
                {
                    idList.Add(tempList[row.RowIndex].ID);
                }
            }

            if (idList.Count > 0)
            {
                foreach (var id in idList)
                    repo.RemoveTask(id);
            }

            PendingGridView.DataSource = repo.GetPendingTasks();
            CompletedGridView.DataSource = repo.GetCompletedTasks();
            Page.DataBind();
            FormatDataGrids();
        }
    }
}