using CommunityToolkit.Maui;
using DevExpress.Maui;
using static DataGridSearchBar.App;

namespace DataGridSearchBar;

public static class MauiProgram {
	public static MauiApp CreateMauiApp() 	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseDevExpress()
			.UseDevExpressCollectionView()
			.UseDevExpressControls()
			.UseDevExpressDataGrid()
			.UseDevExpressEditors()
            .ConfigureFonts(fonts => {
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		return builder.Build();
	}
}

