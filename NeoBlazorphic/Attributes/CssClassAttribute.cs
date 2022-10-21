namespace NeoBlazorphic.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CssClassAttribute : Attribute
    {
        private string cssClass { get; set; }
        private bool defaultValue { get; set; }
        private string category { get; set; }

        /// <summary>
        ///     Serves the purpose of linking css classes to enum values. Hence enabling the client code to handle some UI related things with C# enums rather than CSS.
        /// </summary>
        /// <param name="cssClassName"> The css class to use </param>
        /// <param name="defaultValue"> In case of multiple occurrence of this attribute on a value, the one with defaultValue set to true will be used when no category is mentioned </param>
        /// <param name="category"> In cas of multiple occurrences of this attribute on a value, you can specify a category when getting its value to sort the css class that you actually want </param>
        public CssClassAttribute(string cssClassName, bool defaultValue = true, string category = "")
        {
            this.cssClass = cssClassName;
            this.defaultValue = defaultValue;
            this.category = category;
        }

        public string CssClass => cssClass;
        public string Category => category;
        public bool DefaultValue => defaultValue;
    }

    public static class CssClassAttributesExtensions
    {
        internal static string GetDefaultValue(this CssClassAttribute[] attributes)
        {
            if (attributes.Length == 1)
            {
                return attributes[0].CssClass;
            }

            var defaultAttributes = attributes.Where(x => x.DefaultValue).ToArray();
            if (defaultAttributes.Length != 1)
            {
                Console.WriteLine("WARNING: To be able to fetch the default value for a class, " +
                                  "you should define one and only one CssClassAttribute with default set to true (default value) on an enum value");
                return "";
            }

            return defaultAttributes[0].CssClass;
        }

        internal static string GetValueForCategory(this CssClassAttribute[] attributes, string category)
        {
            var attributesWithCategory = attributes.Where(x => x.Category == category).ToArray();

            if (attributesWithCategory.Length == 0)
            {
                Console.WriteLine($"WARNING: Trying to fetch a CssClassAttribute for category {category}, which does not exist on the given object");
                return "";
            }

            if (attributesWithCategory.Length != 1)
            {
                Console.WriteLine($"WARNING: One and only one category {category} should be defined on a given enum value");
                return "";
            }
            
            return attributesWithCategory[0].CssClass;
        }
    }
}
