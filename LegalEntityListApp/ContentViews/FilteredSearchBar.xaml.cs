using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LegalEntityListApp.ContentViews
{
    public partial class FilteredSearchBar : ContentView
    {
        public FilteredSearchBar()
        {
            InitializeComponent();
        }

        public static BindableProperty PlaceHolderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FilteredSearchBar));

        public static BindableProperty FilterCommandProperty =
            BindableProperty.Create(nameof(FilterCommand), typeof(ICommand), typeof(FilteredSearchBar));

        public static BindableProperty FilterCommandParameterProperty =
            BindableProperty.Create(nameof(FilterCommandParameter), typeof(object), typeof(FilteredSearchBar));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public ICommand FilterCommand
        {
            get { return (ICommand)GetValue(FilterCommandProperty); }
            set { SetValue(FilterCommandProperty, value); }
        }

        public object FilterCommandParameter
        {
            get { return GetValue(FilterCommandParameterProperty); }
            set { SetValue(FilterCommandParameterProperty, value); }
        }

        private void FilterButton_Clicked(object sender, EventArgs e)
        {
            if (FilterCommand?.CanExecute(FilterCommandParameter) ?? false)
            {
                FilterCommand?.Execute(FilterCommandParameter);
            }
        }
    }
}
