using System.ComponentModel;
using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.StyleParameters
{
    public enum BackgroundShape
    {
        [CssClass("flat")] Flat,
        [CssClass("concave")] Concave,
        [CssClass("convex")] Convex
    }
}
