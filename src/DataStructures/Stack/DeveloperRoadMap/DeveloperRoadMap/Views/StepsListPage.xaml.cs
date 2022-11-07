using System.Collections.ObjectModel;
using DeveloperRoadMap.Models;
using DeveloperRoadMap.Models.Extensions;
using DeveloperRoadMap.ViewModels;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DeveloperRoadMap.Views;
#region
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-6.0
// https://www.youtube.com/watch?v=rwpa-d5CtsM
// https://learn.microsoft.com/en-us/dotnet/maui/ios/cli
// https://www.youtube.com/watch?v=J5wC87xE9Qg
// https://github.com/JesseLiberty/LearningMauiPart8/tree/main/LearningMaui-Part8/LearningMaui-Part7
// https://www.youtube.com/watch?v=86r52sv-gJs
// https://github.com/CommunityToolkit/MVVM-Samples/tree/master/samples/MvvmSampleUwp/Views
// https://jesseliberty.com/2022/07/06/learning-net-maui-part-8/
// https://www.spatacoli.com/blog/2022/06/maui-mvvm/
// https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/relaycommand
// https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/commanding
// https://github.com/dotnet/maui-samples
// https://subscribe.packtpub.com/getting-started-with-microsoft-net-maui/
// https://www.codemag.com/Article/2111082/An-Introduction-to-.NET-MAUI
// https://subscribe.packtpub.com/getting-started-with-microsoft-net-maui/
#endregion

public partial class StepsListPage: ContentPage
{
	public StepsListPage()
	{
		InitializeComponent();
        BindingContext = new StepsListViewModel();

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

   
}
