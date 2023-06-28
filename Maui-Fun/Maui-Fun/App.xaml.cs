using Maui_Fun.Controls;
using Maui_Fun.Helpers;

namespace Maui_Fun;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(UnderlineEntry), (handler, view) =>
		{
#if ANDROID
			handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.White);
#elif IOS
			handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
			handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
		});
    }
}

