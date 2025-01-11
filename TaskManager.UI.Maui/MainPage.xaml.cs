using TaskManager.Persistence.Contexts;

namespace TaskManager.UI.Maui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Models.Category category = new();

		category.Name = TitleEntry.Text;

		var context = new TaskManagerEFContext();

		context.Categories!.Add(category);

		context.SaveChanges();

	}
}

