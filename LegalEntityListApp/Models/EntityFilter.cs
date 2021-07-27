using LegalEntityListApp.DataWorkers;

namespace LegalEntityListApp.Models
{
    public class EntityFilter
    {
        [Filter("short_name", FilterType.Like)]
        [Filter("full_name", FilterType.Like)]
        public string Title { get; set; }

        [Filter("psrn", FilterType.Like)]
        public string Psrn { get; set; }

        [Filter("tin", FilterType.Like)]
        public string Tin { get; set; }

        [Filter("rrc", FilterType.Like)]
        public string Rrc { get; set; }

        [Filter("headcount", FilterType.GreaterThan)]
        public int? MinHeadCount { get; set; }

        [Filter("headcount", FilterType.LessThan)]
        public int? MaxHeadCount { get; set; }
    }
}
