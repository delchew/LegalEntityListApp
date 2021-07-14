using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.Comparers
{
    public class PositionLongitudeComparer : IComparer<Position>
    {
        public int Compare(Position x, Position y)
        {
            return x.Longitude.CompareTo(y.Longitude);
        }
    }
}
