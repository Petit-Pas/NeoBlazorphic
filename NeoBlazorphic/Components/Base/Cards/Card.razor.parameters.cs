using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Base.Cards;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class Card
{
    /// <summary>
    ///     The content of the card
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    ///     Exposing click event on the card
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnMouseClickCallBack { get; set; }

    /// <summary>
    ///     The color of the card
    /// </summary>
    [Parameter]
    public virtual ThemeColor Color { get; set; } = ThemeColor.Base;

    /// <summary>
    ///     The shadow position of the card
    /// </summary>
    [Parameter]
    public virtual ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

    /// <summary>
    ///     The shape of the card
    /// </summary>
    [Parameter]
    public virtual BackgroundShape Shape { get; set; } = BackgroundShape.Flat;

    /// <summary>
    ///     The BorderRadius of the card
    /// </summary>
    [Parameter]
    public virtual BorderRadius BorderRadius { get; set; } = BorderRadius.Default;

    /// <summary>
    ///     The margin of the card
    /// </summary>
    [Parameter]
    public virtual Spacing Margin { get; set; } = Spacing._0;

    /// <summary>
    ///     The padding of the card
    /// </summary>
    [Parameter]
    public virtual Spacing Padding { get; set; } = Spacing._3;

    /// <summary>
    ///     Tells whether the text can be selected or not in the card
    /// </summary>
    [Parameter]
    public virtual bool SelectableText { get; set; } = false;

    /// <summary>
    ///     Just some additional classes to add to the card container. Can be used to override some default behavior by reusing the css variables of the library 
    /// </summary>
    [Parameter]
    public virtual string AdditionalClasses { get; set; } = "";

    // UI Methods

    protected virtual string ColorClass => Color.GetCssClass();
    protected virtual string ShadowClass => ShadowPosition.GetCssClass();
    protected virtual string ShapeClass => Shape.GetCssClass();
    protected virtual string BorderRadiusStyle => BorderRadius.GetCssProperty();
    protected virtual string PaddingClass => Padding.GetCssClass("padding");
    protected virtual string MarginClass => Margin.GetCssClass("margin");
    protected virtual string SelectableTextClass => SelectableText ? "" : "prevent-select";

}