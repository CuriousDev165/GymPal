using GymPal.Core.ViewModels;

namespace GymPal
{
    public partial class MainPage : ContentPage
    {
        private bool isFirstLoad = true;

        public MainPage(MainPageViewModel viewModel)
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
}
