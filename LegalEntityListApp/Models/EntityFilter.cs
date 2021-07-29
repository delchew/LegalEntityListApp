using LegalEntityListApp.DataWorkers;

namespace LegalEntityListApp.Models
{
    public class EntityFilter
    {
        [Filter("[or][0][short_name][like]")]
        [Filter("[or][1][full_name][like]")]
        public string Title { get; set; }

        [Filter("[psrn][like]")]
        public string Psrn { get; set; }

        [Filter("[tin][like]")]
        public string Tin { get; set; }

        [Filter("[rrc][like]")]
        public string Rrc { get; set; }

        [Filter("[headcount][gte]")]
        public int? MinHeadCount { get; set; }

        [Filter("[headcount][lte]")]
        public int? MaxHeadCount { get; set; }
    }
}
