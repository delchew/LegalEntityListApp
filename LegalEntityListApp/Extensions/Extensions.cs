using System;
using System.ComponentModel;
using System.Reflection;
using LegalEntityListApp.Models;
using Xamarin.Forms.Maps;

namespace LegalEntityListApp.Extensions
{
    public static class Extensions
    {
        public static Position ToPosition(this Location location)
        {
            if (location.Latitude.HasValue && location.Longitude.HasValue)
            {
                return new Position(location.Latitude.Value, location.Longitude.Value);
            }
            throw new ArgumentNullException("Some of Location properties are equal null!");
        }

        public static string GetDescription(this Enum enumElement)
        {
            var enumItemName = enumElement.ToString();
            var memberInfo = enumElement.GetType()
                                        .GetMember(enumItemName);
            if (memberInfo == null && memberInfo.Length == 0)
            {
                return enumItemName;
            }
            var descriptionAttr = memberInfo[0].GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttr?.Description ?? enumItemName;
        }
    }
}
