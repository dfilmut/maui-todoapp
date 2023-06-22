namespace todoApp.Views.Controls;

public partial class TaskControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public TaskControl()
	{
		InitializeComponent();
	}

    public string Title
    {
        get
        {
            return entryTitle.Text;
        }

        set
        {
            entryTitle.Text = value;
        }
    }
    public string Description
    {
        get
        {
            return entryDescription.Text;
        }

        set
        {
            entryDescription.Text = value;
        }
    }
    //public string Status
    //{
    //    get
    //    {
    //        return entryStatus.Text;
    //    }

    //    set
    //    {
    //        entryStatus.Text = value;
    //    }
    //}

    public string Status
    {
        get => entryStatus.SelectedItem as string;
        set
        {
            entryStatus.SelectedItem = value;
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (titleValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Title is required.");
            return;
        }

        OnSave?.Invoke(sender, e);
    }
    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }

}