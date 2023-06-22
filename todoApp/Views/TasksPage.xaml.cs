namespace todoApp.Views;

using System.Collections.ObjectModel;
using todoApp.Models;
using Task = todoApp.Models.Task;

public partial class TasksPage : ContentPage
{
	public TasksPage()
	{
		InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadTasks();
    }

    private async void listTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //if (listTasks.SelectedItem != null)
        if (listTasks.SelectedItem != null)
        {
            //await Shell.Current.GoToAsync($"{nameof(EditTask)}?Id={((Task)listTasks.SelectedItem).TaskId}");
            await Shell.Current.GoToAsync($"{nameof(EditTask)}?Id={((Task)listTasks.SelectedItem).TaskId}");

        }
    }
    private void listTasks_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //listTasks.SelectedItem = null;
        listTasks.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddTask));
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var task = menuItem.CommandParameter as Task;
        TaskRepository.DeleteTask(task.TaskId);

        LoadTasks();
    }

    private void LoadTasks()
    {
        var tasks = new ObservableCollection<Task>(TaskRepository.GetTasks());
        listTasks.ItemsSource = tasks;
    }

}