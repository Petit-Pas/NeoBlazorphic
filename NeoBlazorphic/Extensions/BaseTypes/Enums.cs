using System.ComponentModel;
using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.Extensions.BaseTypes
{
    public static class EnumExtensions
    {
        private static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                ?.GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault()!;
        }

        public static string GetCssClass(this Enum value)
        {
            var attribute = GetAttribute<CssClassAttribute>(value);
            return attribute != null ? attribute.CssClass : $"unknown css class for item {value}";
        }
    }
}
