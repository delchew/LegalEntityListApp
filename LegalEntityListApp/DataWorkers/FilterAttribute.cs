using System;

namespace LegalEntityListApp.DataWorkers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FilterAttribute : Attribute
    {
        public string Parameter { get; }

        public FilterAttribute(string parameter)
        {
            Parameter = parameter;
        }
    }
}
