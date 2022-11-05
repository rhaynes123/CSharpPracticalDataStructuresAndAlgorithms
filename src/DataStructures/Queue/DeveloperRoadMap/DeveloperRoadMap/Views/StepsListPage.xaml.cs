using System.Collections.ObjectModel;
using DeveloperRoadMap.Models;
using DeveloperRoadMap.Models.Extensions;

namespace DeveloperRoadMap.Views;
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-6.0
// https://www.youtube.com/watch?v=rwpa-d5CtsM
// https://learn.microsoft.com/en-us/dotnet/maui/ios/cli
// https://www.youtube.com/watch?v=J5wC87xE9Qg
public partial class StepsListPage : ContentPage
{
	private ObservableQueue<Step> QueuedSteps = new ObservableQueue<Step>();
	public StepsListPage()
	{
		InitializeComponent();
		QueuedSteps.Push(new Step("Learn variables"));
        QueuedSteps.Push(new Step("Learn if else"));
		QueuedSteps.Push(new Step("Learn For loops"));
        QueuedSteps.Push(new Step("Learn Functions"));
		QueuedSteps.Push(new Step("Learn Classes"));
		QueuedSteps.Push(new Step("Become C# Developer"));

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		listView.ItemsSource = QueuedSteps;
    }

	private void StepComplete(object sender, EventArgs e)
    {
		QueuedSteps.Pop();
    }
}
