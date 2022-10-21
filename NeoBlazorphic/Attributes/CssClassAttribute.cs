namespace NeoBlazorphic.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CssClassAttribute : Attribute
    {
        private string cssClass { get; set; }

        public CssClassAttribute(string cssClassName)
        {
            cssClass = cssClassName;
        }

        public string CssClass => cssClass;
    }
}
