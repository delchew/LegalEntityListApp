using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LegalEntityListApp.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace LegalEntityListApp.ViewModels
{
    public class FiltersPopupViewModel : INotifyPropertyChanged
    {
        private readonly EntityFilter _entityFilter;
        private Action<EntityFilter> _filteredSearchAction;

        public ICommand ApplyFilterCommand { get; private set; }

        public FiltersPopupViewModel(Action<EntityFilter> filteredSearchAction)
        {
            _entityFilter = new EntityFilter();
            ApplyFilterCommand = new Command(ApplyFilter);
            _filteredSearchAction = filteredSearchAction;
        }

        #region Filter Binding Properties
        public string Title
        {
            get { return _entityFilter.Title; }
            set
            {
                if (_entityFilter.Title != value)
                {
                    _entityFilter.Title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Psrn
        {
            get { return _entityFilter.Psrn; }
            set
            {
                if (_entityFilter.Psrn != value)
                {
                    _entityFilter.Psrn = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Tin
        {
            get { return _entityFilter.Tin; }
            set
            {
                if (_entityFilter.Tin != value)
                {
                    _entityFilter.Tin = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Rrc
        {
            get { return _entityFilter.Rrc; }
            set
            {
                if (_entityFilter.Rrc != value)
                {
                    _entityFilter.Rrc = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? MinHeadCount
        {
            get { return _entityFilter.MinHeadCount; }
            set
            {
                if (_entityFilter.MinHeadCount != value)
                {
                    _entityFilter.MinHeadCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? MaxHeadCount
        {
            get { return _entityFilter.MaxHeadCount; }
            set
            {
                if (_entityFilter.MaxHeadCount != value)
                {
                    _entityFilter.MaxHeadCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private async void ApplyFilter()
        {
            await PopupNavigation.Instance.PopAsync();
            _filteredSearchAction?.Invoke(_entityFilter);
        }
    }
}
