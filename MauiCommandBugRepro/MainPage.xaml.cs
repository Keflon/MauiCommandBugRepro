namespace MauiCommandBugRepro;

public partial class MainPage : ContentPage
{
	int count = 0;
    public Command DelayCommand { get; }

    public MainPage()
	{
		DelayCommand = new Command(DoDelay, CanDoDelay);
        InitializeComponent();
	}

	public bool PreventDelay { get; set; }

    private async void DoDelay()
    {
        PreventDelay = true;
        DelayCommand.ChangeCanExecute();
        await Task.Delay(1000);
        PreventDelay = false;
        DelayCommand.ChangeCanExecute();
    }

    private bool CanDoDelay()
    {
        return !PreventDelay;
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

