using GymPal.Core.ViewModels;

namespace GymPal.Pages;

public partial class RecordsPage : ContentPage
{
    private bool isFirstLoad = true;

    public RecordsPage(RecordsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (isFirstLoad && BindingContext is MainPageViewModel viewModel)
        {
            viewModel.GetMovementsCommand.Execute(null);
            isFirstLoad = false;
        }
    }
}