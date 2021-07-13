using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LegalEntityListApp.Models;
using Newtonsoft.Json;

namespace LegalEntityListApp.ViewModels
{
    public class LegalEntityViewModel : INotifyPropertyChanged
    {
        private LegalEntity _legalEntity = new LegalEntity();

        [JsonProperty("id")]
        public int Id
        {
            get { return _legalEntity.Id; }
            set
            {
                if(_legalEntity.Id != value)
                {
                    _legalEntity.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("short_name")]
        public string ShortName
        {
            get { return _legalEntity.ShortName; }
            set
            {
                if (_legalEntity.ShortName != value)
                {
                    _legalEntity.ShortName = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("full_name")]
        public string FullName
        {
            get { return _legalEntity.FullName; }
            set
            {
                if (_legalEntity.FullName != value)
                {
                    _legalEntity.FullName = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("address")]
        public string Address
        {
            get { return _legalEntity.Address; }
            set
            {
                if (_legalEntity.Address != value)
                {
                    _legalEntity.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("psrn")]
        public string Psrn
        {
            get { return _legalEntity.Psrn; }
            set
            {
                if (_legalEntity.Psrn != value)
                {
                    _legalEntity.Psrn = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("registration_date")]
        public DateTime RegistrationDate
        {
            get { return _legalEntity.RegistrationDate; }
            set
            {
                if (_legalEntity.RegistrationDate != value)
                {
                    _legalEntity.RegistrationDate = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("tin")]
        public string Tin
        {
            get { return _legalEntity.Tin; }
            set
            {
                if (_legalEntity.Tin != value)
                {
                    _legalEntity.Tin = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("rrc")]
        public string Rrc
        {
            get { return _legalEntity.Rrc; }
            set
            {
                if (_legalEntity.Rrc != value)
                {
                    _legalEntity.Rrc = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("authorized_capital", NullValueHandling = NullValueHandling.Ignore)]
        public double AuthorizedCapital
        {
            get { return _legalEntity.AuthorizedCapital; }
            set
            {
                if (_legalEntity.AuthorizedCapital != value)
                {
                    _legalEntity.AuthorizedCapital = value;
                    OnPropertyChanged();
                }
            }
        }
        [JsonProperty("legal_form")]

        public string LegalForm
        {
            get { return _legalEntity.LegalForm; }
            set
            {
                if (_legalEntity.LegalForm != value)
                {
                    _legalEntity.LegalForm = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("ownership_form")]
        public string OwnershipForm
        {
            get { return _legalEntity.OwnershipForm; }
            set
            {
                if (_legalEntity.OwnershipForm != value)
                {
                    _legalEntity.OwnershipForm = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("industry")]
        public string Industry
        {
            get { return _legalEntity.Industry; }
            set
            {
                if (_legalEntity.Industry != value)
                {
                    _legalEntity.Industry = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("head_position")]
        public string HeadPosition
        {
            get { return _legalEntity.HeadPosition; }
            set
            {
                if (_legalEntity.HeadPosition != value)
                {
                    _legalEntity.HeadPosition = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("head_full_name")]
        public string HeadFullName
        {
            get { return _legalEntity.HeadFullName; }
            set
            {
                if (_legalEntity.HeadFullName != value)
                {
                    _legalEntity.HeadFullName = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("head_itn")]
        public string HeadItn
        {
            get { return _legalEntity.HeadItn; }
            set
            {
                if (_legalEntity.HeadItn != value)
                {
                    _legalEntity.HeadItn = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("organization_status")]
        public string OrganizationStatus
        {
            get { return _legalEntity.OrganizationStatus; }
            set
            {
                if (_legalEntity.OrganizationStatus != value)
                {
                    _legalEntity.OrganizationStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("location")]
        public Location Location
        {
            get { return _legalEntity.Location; }
            set
            {
                if (!_legalEntity.Location.Equals(value))
                {
                    _legalEntity.Location = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
