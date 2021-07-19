using System;
using LegalEntityListApp.Models;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.Extensions
{
    public static class Extensions
    {
        public static Position ToPosition(this Location location)
        {
            if (location.Latitude.HasValue && location.Longitude.HasValue)
            {
                return new Position(location.Latitude.Value, location.Longitude.Value);
            }
            throw new ArgumentNullException("Some of Location properties are equal null!");
        }
    }
}
