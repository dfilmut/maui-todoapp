using todoApp.Models;
namespace todoApp.Views;

public partial class AddTask : ContentPage
{
	public AddTask()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(TasksPage)}");
    }

    private void taskCtrl_OnSave(object sender, EventArgs e)
    {
        TaskRepository.AddTask(new Models.Task
        {
            Title = taskCtrl.Title,
            Description = taskCtrl.Description,
            Status = taskCtrl.Status
        });

        Shell.Current.GoToAsync($"//{nameof(TasksPage)}");
    }

    private void taskCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(TasksPage)}");
    }

    private void taskCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }

}