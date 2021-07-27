using System;

namespace LegalEntityListApp.DataWorkers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FilterAttribute : Attribute
    {
        public string ParameterName { get; }
        public FilterType FilterType { get; }

        public FilterAttribute(string parameterName, FilterType filterType)
        {
            ParameterName = parameterName;
            FilterType = filterType;
        }
    }
}
