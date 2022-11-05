using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.StyleParameters
{
    public enum Spacing
    {
        [CssClass("p-0", false, "padding")]
        [CssClass("m-0", false, "margin")]
        _0,
        [CssClass("p-1", false, "padding")]
        [CssClass("m-1", false, "margin")]
        _1,
        [CssClass("p-2", false, "padding")]
        [CssClass("m-2", false, "margin")]
        _2,
        [CssClass("p-3", false, "padding")]
        [CssClass("m-3", false, "margin")]
        _3,
        [CssClass("p-5", false, "padding")]
        [CssClass("m-5", false, "margin")]
        _5,
        [CssClass("p-10", false, "padding")]
        [CssClass("m-10", false, "margin")]
        _10
    }
}
