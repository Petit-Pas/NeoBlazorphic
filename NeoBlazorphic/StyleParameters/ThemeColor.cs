using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.StyleParameters
{
    public enum ThemeColor
    {
        [CssClass("")]
        None,
        [CssClass("neo-base")]
        Base,
        [CssClass("neo-primary")]
        Primary,
        [CssClass("neo-danger")]
        Danger
    }
}
