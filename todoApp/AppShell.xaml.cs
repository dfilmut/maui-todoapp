using todoApp.Views;
namespace todoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(TasksPage), typeof(TasksPage));
        Routing.RegisterRoute(nameof(AddTask), typeof(AddTask));
        Routing.RegisterRoute(nameof(EditTask), typeof(EditTask));
    }
}
