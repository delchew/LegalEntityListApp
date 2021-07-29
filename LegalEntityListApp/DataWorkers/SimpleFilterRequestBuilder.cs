using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using LegalEntityListApp.Models;

namespace LegalEntityListApp.DataWorkers
{
    public class SimpleFilterRequestBuilder : IRequestStringBuilder
    {
        private readonly IDictionary<string, string> _queryParamsDictionary;
        private readonly string _baseRequestString = @"https://beta.marketing-logic.ru/mlead/api/v0/legals";
        private readonly string _accessTokenString  = @"zCdJIdkcU5rGTG0lsngcrDGfsmEAV4Kz";
        private readonly PropertyInfo[] _filterProps = typeof(EntityFilter).GetProperties();

        public SimpleFilterRequestBuilder()
        {
            _queryParamsDictionary = new Dictionary<string, string>
            {
                { "access-token", _accessTokenString }
            };
        }

        public string GetRequestString(int pageNumber = 1, EntityFilter filter = null)
        {
            _queryParamsDictionary["page"] = pageNumber.ToString();
            if (filter != null)
            {
                foreach (var prop in _filterProps)
                {
                    var propValue = prop.GetValue(filter);
                    if(propValue != null)
                    {
                        var attrs = prop.GetCustomAttributes<FilterAttribute>();
                        foreach (var attr in attrs)
                        {
                            _queryParamsDictionary[$"filter{attr.Parameter}"] = propValue.ToString();
                        }
                    }
                }
            }
            var encodedContent = new FormUrlEncodedContent(_queryParamsDictionary);
            var queryParamsString = encodedContent.ReadAsStringAsync().Result;
            return $"{_baseRequestString}?{queryParamsString}";
        }
    }
}
