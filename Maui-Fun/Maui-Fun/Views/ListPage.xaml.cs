using Maui_Fun.ViewModels;

namespace Maui_Fun.Views;

public partial class ListPage : ContentPage
{
	public ListPage(ListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        
    }

    void TapGestureRecognizer_Tapped_1(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void TapGestureRecognizer_Tapped_2(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    { 
    }
}
