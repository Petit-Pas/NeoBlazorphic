using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.Extensions.BaseTypes;

namespace NeoBlazorphic.Components.Inputs.Buttons;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class ButtonCard
{
    /// <summary>
    ///     The content of the button
    /// </summary>
    [Parameter]
    public virtual RenderFragment? ChildContent { get; set; }

    /// <summary>
    ///     An event tu subscribe for the click
    /// </summary>
    [Parameter]
    public virtual EventCallback<MouseEventArgs> OnMouseClickCallBack { get; set; }

    /// <summary>
    ///     The color of the button card
    /// </summary>
    [Parameter]
    public virtual ThemeColor Color { get; set; } = ThemeColor.Base;
        
    /// <summary>
    ///     The BorderRadius of the card
    /// </summary>
    [Parameter]
    public virtual BorderRadius BorderRadius { get; set; } = BorderRadius.Default;

    /// <summary>
    ///     The padding of the card
    /// </summary>
    [Parameter]
    public virtual Spacing Padding { get; set; } = Spacing._3;

    /// <summary>
    ///     Tells if the checkbox should be enabled
    /// </summary>
    [Parameter]
    public virtual bool IsEnabled { get; set; } = true;

    // UI Methods
    protected virtual string EnabledClass => IsEnabled switch
    {
        true => "enabled",
        false => "disabled",
    };
    protected virtual string ColorClass => Color.GetCssClass();
    protected virtual string BorderRadiusStyle => BorderRadius.GetCssProperty();
    protected virtual string PaddingClass => Padding.GetCssClass("padding");

}