using System.Windows.Input;
using Xamarin.Forms;

namespace LegalEntityListApp.ContentViews
{
    public partial class CompanyContentView : ContentView
    {
        public static readonly BindableProperty CompanyNameProperty =
            BindableProperty.Create(nameof(CompanyName), typeof(string), typeof(CompanyContentView));

        public static readonly BindableProperty CompanyTinProperty =
            BindableProperty.Create(nameof(CompanyTin), typeof(string), typeof(CompanyContentView));

        public static readonly BindableProperty CompanyRrcProperty =
            BindableProperty.Create(nameof(CompanyRrc), typeof(string), typeof(CompanyContentView));

        public static readonly BindableProperty CompanyPsrnProperty =
            BindableProperty.Create(nameof(CompanyPsrn), typeof(string), typeof(CompanyContentView));

        public static readonly BindableProperty CompanyAddressProperty =
            BindableProperty.Create(nameof(CompanyAddress), typeof(string), typeof(CompanyContentView));

        public static readonly BindableProperty MoreButtonClickCommandProperty =
            BindableProperty.Create(nameof(MoreButtonClickCommand), typeof(Command), typeof(CompanyContentView), propertyChanged: OnCommandPropertyChanged);

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as CompanyContentView).MoreButtonClickCommand = (Command)newValue;
        }

        public string CompanyName
        {
            get { return (string)GetValue(CompanyNameProperty); }
            set { SetValue(CompanyNameProperty, value); }
        }

        public string CompanyTin
        {
            get { return (string)GetValue(CompanyTinProperty); }
            set { SetValue(CompanyTinProperty, value); }
        }

        public string CompanyRrc
        {
            get { return (string)GetValue(CompanyRrcProperty); }
            set { SetValue(CompanyRrcProperty, value); }
        }

        public string CompanyPsrn
        {
            get { return (string)GetValue(CompanyPsrnProperty); }
            set { SetValue(CompanyPsrnProperty, value); }
        }

        public string CompanyAddress
        {
            get { return (string)GetValue(CompanyAddressProperty); }
            set { SetValue(CompanyAddressProperty, value); }
        }

        public ICommand MoreButtonClickCommand
        {
            get { return (Command)GetValue(MoreButtonClickCommandProperty); }
            set { SetValue(MoreButtonClickCommandProperty, value); }
        }

        public CompanyContentView()
        {
            InitializeComponent();
        }
    }
}
