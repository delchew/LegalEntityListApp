using LegalEntityListApp.Models;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.Extensions
{
    public static class Extensions
    {
        public static Position ToPosition (this Location location)
        {
            return new Position(location.Latitude, location.Longitude);
        }
    }
}
