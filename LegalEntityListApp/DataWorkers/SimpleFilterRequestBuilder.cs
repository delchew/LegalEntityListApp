using System.Reflection;
using System.Text;
using LegalEntityListApp.Extensions;
using LegalEntityListApp.Models;

namespace LegalEntityListApp.DataWorkers
{
    public class SimpleFilterRequestBuilder : IRequestStringBuilder
    {
        private const int _minRequestStringLength = 120;
        private readonly StringBuilder _requestStringBuilder = new StringBuilder(_minRequestStringLength);

        public string BaseRequestString { get; set; } = @"https://beta.marketing-logic.ru/mlead/api/v0/legals";
        public string AccessTokenString { get; set; } = @"zCdJIdkcU5rGTG0lsngcrDGfsmEAV4Kz";

        public string GetRequestString(int pageNumber = 1, EntityFilter filter = null)
        {
            _requestStringBuilder.Clear().Append(BaseRequestString).Append("?");
            _requestStringBuilder.Append("access-token=").Append(AccessTokenString);
            _requestStringBuilder.Append("&page=").Append(pageNumber);
            if (filter != null)
            {
                var properties = filter.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var propValue = prop.GetValue(filter);
                    if(propValue != null)
                    {
                        var attrs = prop.GetCustomAttributes<FilterAttribute>();
                        foreach (var attr in attrs)
                        {
                            AddFilterParameter(attr.ParameterName, attr.FilterType.GetDescription(), propValue.ToString());
                        }
                    }
                }
            }
            
            return _requestStringBuilder.ToString();
        }

        private void AddFilterParameter(string name, string filterType, string value)
        {
            
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(filterType) && !string.IsNullOrWhiteSpace(value))
            {
                _requestStringBuilder.Append("&filter[")
                                     .Append(name)
                                     .Append("][")
                                     .Append(filterType)
                                     .Append("]=")
                                     .Append(value);
            }
        }
    }
}
