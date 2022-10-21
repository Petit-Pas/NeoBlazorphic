using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.Extensions.BaseTypes
{
    public static class EnumExtensions
    {
        private static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == default)
            {
                Console.WriteLine($"WARNING: Could not find the name {value} in enum {type}");
                return Array.Empty<TAttribute>();
            }
            var field = type.GetField(name);
            if (field == default)
            {
                Console.WriteLine($"WARNING: Could not find the field {name} in enum {type}");
                return Array.Empty<TAttribute>();
            }
            return field.GetCustomAttributes(false)
                .OfType<TAttribute>();
        }

        public static string GetCssClass(this Enum value, string? category = default)
        {
            var attributes = value.GetAttributes<CssClassAttribute>().ToArray();

            if (attributes.Length == 0)
            {
                Console.WriteLine($"WARNING: Could not find CssClassAttribute for {value}");
                return "";
            }

            return string.IsNullOrEmpty(category)
                ? attributes.GetDefaultValue() 
                : attributes.GetValueForCategory(category);
        }
    }
}

