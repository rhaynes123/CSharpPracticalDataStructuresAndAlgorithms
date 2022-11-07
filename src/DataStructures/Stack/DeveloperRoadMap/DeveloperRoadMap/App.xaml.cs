using DeveloperRoadMap.Views;

namespace DeveloperRoadMap;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new StepsListPage())
        {
			BarTextColor = Color.FromRgb(255,255,255),
        };
	}
}

