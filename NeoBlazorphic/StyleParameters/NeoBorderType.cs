using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.StyleParameters
{
    public enum NeoBorderType
    {
        [CssClass("")] None,
        [CssClass("neo-shadow-out")] NeoShadowOut,
        [CssClass("neo-shadow-in")] NeoShadowIn,
        [CssClass("neo-light-border")] NeoLightBorder
    }
}
