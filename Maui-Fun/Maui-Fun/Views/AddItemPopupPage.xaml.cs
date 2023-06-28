using Maui_Fun.ViewModels;

namespace Maui_Fun.Views;

public partial class AddItemPopupPage
{
    public AddItemPopupPage(ListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
