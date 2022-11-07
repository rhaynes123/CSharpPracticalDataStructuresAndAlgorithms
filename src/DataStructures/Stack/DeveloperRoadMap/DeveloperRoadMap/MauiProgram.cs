namespace DeveloperRoadMap;
#region
// https://developer.apple.com/forums/thread/660649?login=true
// https://github.com/dotnet/maui/issues/3888
// https://www.youtube.com/watch?v=rwpa-d5CtsM
#endregion
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

