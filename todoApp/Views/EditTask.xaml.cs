using Task = todoApp.Models.Task;
using todoApp.Models;

namespace todoApp.Views;

[QueryProperty(nameof(TaskId), "Id")]
public partial class EditTask : ContentPage
{
    //private global::todoApp.Views.Controls.TaskControl taskCtrl;
    private Task task;
	public EditTask()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    public string TaskId
    {
        set
        {
            task = TaskRepository.GetTaskById(int.Parse(value));
            if (task != null)
            {
                taskCtrl.Title = task.Title;
                taskCtrl.Description = task.Description;
                taskCtrl.Status = task.Status;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        task.Title = taskCtrl.Title;
        task.Description = taskCtrl.Description;
        task.Status = taskCtrl.Status;


        TaskRepository.UpdateTask(task.TaskId, task);
        Shell.Current.GoToAsync("..");
    }

    private void taskCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}