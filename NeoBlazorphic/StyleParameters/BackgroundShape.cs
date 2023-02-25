using System.ComponentModel;
using NeoBlazorphic.Attributes;

namespace NeoBlazorphic.StyleParameters
{
    public enum BackgroundShape
    {
        [CssClass("none")]
        None,
        [CssClass("neo-flat")]
        Flat,
        [CssClass("neo-concave")]
        Concave,
        [CssClass("neo-convex")]
        Convex
    }
}
