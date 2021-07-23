using System;
namespace LegalEntityListApp.Models
{
    public class LegalEntity
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Psrn { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Tin { get; set; }

        public string Rrc { get; set; }

        public double? AuthorizedCapital { get; set; }

        public string LegalForm { get; set; }

        public string OwnershipForm { get; set; }

        public string Industry { get; set; }

        public string HeadPosition { get; set; }

        public string HeadFullName { get; set; }

        public string HeadItn { get; set; }

        public string OrganizationStatus { get; set; }

        public Location Location { get; set; }
    }
}
