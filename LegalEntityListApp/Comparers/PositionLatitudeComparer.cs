using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.Comparers
{
    public class PositionLatitudeComparer : IComparer<Position>
    {
        public int Compare(Position x, Position y)
        {
            return x.Latitude.CompareTo(y.Latitude);
        }
    }
}
