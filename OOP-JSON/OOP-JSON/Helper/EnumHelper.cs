using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_JSON.Helper
{
    public static class EnumHelper
    {
        public static T GetAtt<T>(this Enum value) where T : Attribute
        {
            var attribute = value.GetType()
                .GetRuntimeField(value.ToString())
                .GetCustomAttributes(typeof(T), false)
                .SingleOrDefault() as T;
            return attribute;
        }

        public static DisplayAttribute GetDisplayAtt(this Enum value)
        {
            return GetAtt<DisplayAttribute>(value);
        }
        public static string GetDescriptionAtt(this Enum value)
        {
            DisplayAttribute attribute = GetDisplayAtt(value);
            return attribute != null ? attribute.Description : "";
        }

        public static List<string> GetListDescription<T>() where T : Enum
        {
            var eValue = Enum.GetValues(typeof(T)).Cast<T>().Select(i => i.GetDescriptionAtt()).ToList();
            return eValue.Where(i => i != null).ToList();
        }
    }
}
