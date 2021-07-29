using System.Collections.Generic;
using System.Windows.Input;
using LegalEntityListApp.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.ViewModels
{
    public class MapPageViewModel
    {
        private IList<LegalEntityViewModel> _companies;

        public INavigation Navigation { get; set; }
        public ICommand BackToMainPageCommand { get; private set; }

        public MapPageViewModel(IList<LegalEntityViewModel> companies)
        {
            _companies = companies;
            BackToMainPageCommand = new Command(async () => await Navigation.PopAsync());
        }

        public IEnumerable<Pin> GetPins()
        {
            foreach (var item in _companies)
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
