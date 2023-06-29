using CommunityToolkit.Maui;
using Maui_Fun.Context;
using Maui_Fun.Helpers.Interfaces;
using Maui_Fun.Helpers.Services;
using Maui_Fun.ViewModels;
using Maui_Fun.Views;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;

namespace Maui_Fun;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureMopups()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Geologica-Bold.ttf", "OpenSansSemibold");
                fonts.AddFont("Geologica-Regular.ttf", "OpenSansSemibold");
                fonts.AddFont("FontAwesomeRegular.otf", "FontAwesomeRegular");
                fonts.AddFont("FontAwesomeSolid.otf", "FontAwesomeSolid");
				
            });
		builder.Services.AddSingleton<ItemRepository>();
		builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);
        builder.Services.AddTransient<ListPage>();
        builder.Services.AddTransient<ListViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

