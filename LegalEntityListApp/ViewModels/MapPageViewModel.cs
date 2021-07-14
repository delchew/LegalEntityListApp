using System.Collections.Generic;
using LegalEntityListApp.Extensions;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.ViewModels
{
    public class MapPageViewModel
    {
        private MainPageViewModel _mainPageViewModel { get; }

        public MapPageViewModel(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        public IEnumerable<Pin> GetPins()
        {
            foreach (var item in _mainPageViewModel.Companies)
            {
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Address = item.Address,
                    Label = item.ShortName,
                    Position = item.Location.ToPosition()
                };
                yield return pin;
            }
        }

    }
}
