using System.Collections.Generic;
using LegalEntityListApp.Extensions;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.ViewModels
{
    public class MapPageViewModel
    {
        private IList<LegalEntityViewModel> _companies;

        public MapPageViewModel(IList<LegalEntityViewModel> companies)
        {
            _companies = companies;
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
