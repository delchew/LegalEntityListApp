using System;
using System.Collections.Generic;
using System.Linq;
using LegalEntityListApp.Comparers;
using LegalEntityListApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.Views
{
    public partial class MapPage : ContentPage
    {
        private const int EdgeSpaceInMetres = 100;

        public MapPage(MapPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Navigation = Navigation;
            var pins = viewModel.GetPins();
            foreach(var pin in pins)
            {
                map.Pins.Add(pin);
            }

            map.MoveToRegion(GetPinsMapSpan(pins));
        }

        private MapSpan GetPinsMapSpan(IEnumerable<Pin> pins)
        {
            var positions = pins.Select(x => x.Position).ToArray();

            Array.Sort(positions, new PositionLatitudeComparer());
            var latMin = positions[0].Latitude;
            var latMax = positions[positions.Length - 1].Latitude;
            var centerLat = (latMin + latMax) / 2;
            var distanceBetweenMinMaxLatPositions = Distance.BetweenPositions(positions[0], new Position(latMax, positions[0].Longitude));

            Array.Sort(positions, new PositionLongitudeComparer());
            var longMin = positions[0].Longitude;
            var longMax = positions[positions.Length - 1].Longitude;
            var centerLong = (longMin + longMax) / 2;
            var distanceBetweenMinMaxLongPositions = Distance.BetweenPositions(positions[0], new Position(positions[0].Latitude, longMax));

            var areaRadius = new Distance(Math.Max(distanceBetweenMinMaxLatPositions.Meters, distanceBetweenMinMaxLongPositions.Meters) / 2 + EdgeSpaceInMetres);
            return MapSpan.FromCenterAndRadius(new Position(centerLat, centerLong), areaRadius);
        }
    }
}
