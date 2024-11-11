using Payment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Helper
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
            return attribute != null ? (attribute.Description ?? null) : "";
        }

        public static List<Selectable<T>> GetEnumSelectable<T>() where T : Enum
        {
            var enumValue = GetEnumValue<T>();
            return enumValue.Select(x =>
            {
                var val = x;
                string label = GetDescriptionAtt(val);
                return new Selectable<T>(val, label);
            }).ToList();

        }

        public static List<T> GetEnumValue<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static List<string> GetListDescription<T>() where T : Enum
        {
            var eValue = Enum.GetValues(typeof(T)).Cast<T>().Select(i => i.GetDescriptionAtt()).ToList();
            return eValue.Where(i => i != null).ToList();
        }

        public static bool CheckValueInEnum<T>(this int value) where T : Enum
        {
            var enumValue = GetEnumValue<T>().Select(i => (int)(object)i);
            return enumValue.Contains(value);
        }
    }
}
