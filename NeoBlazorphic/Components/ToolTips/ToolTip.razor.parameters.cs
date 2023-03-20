using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.ToolTips;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class ToolTip
{
    [Parameter]
    public virtual RenderFragment? ChildContent { get; set; }

    /// <summary>
    ///     The client code should always provide either ToolTipContent or Text, never both.
    ///     In case both are provided, ToolTipContent will prevail.
    /// 
    ///     This is a div that will be displayed in the tooltip
    /// </summary>
    [Parameter]
    public virtual RenderFragment? ToolTipContent { get; set; }

    /// <summary>
    ///     The client code should always provide either ToolTipContent or Text, never both.
    ///     In case both are provided, ToolTipContent will prevail.
    /// 
    ///     This is a simple text that will be displayed in the tooltip
    /// </summary>
    [Parameter]
    public virtual string Text { get; set; } = "tooltip";

    /// <summary>
    ///     Position of the label compared to the ChildContent
    /// </summary>
    [Parameter]
    public virtual ElementRelativePosition LabelPosition { get; set; } = ElementRelativePosition.Bottom;

    /// <summary>
    ///     Will make the tooltip always visible
    /// </summary>
    [Parameter]
    public virtual bool ForceVisible { get; set; } = false;

    // UI Methods

    protected virtual string OverrideVisibilityClass => ForceVisible switch
    {
        true => "enforce-visible",
        false => ""
    };
}