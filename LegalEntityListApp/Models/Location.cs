namespace LegalEntityListApp.Models
{
    public struct Location
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Location location)
            {
                return Latitude == location.Latitude &&
                       Longitude == location.Longitude;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hash = 19;
            hash = hash * 37 + Latitude.GetHashCode();
            hash = hash * 37 + Longitude.GetHashCode();
            return hash;
        }
    }
}