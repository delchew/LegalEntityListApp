using LegalEntityListApp.ViewModels;

namespace LegalEntityListApp.Views
{
    public partial class FiltersPopupView
    {
        public FiltersPopupView(FiltersPopupViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
