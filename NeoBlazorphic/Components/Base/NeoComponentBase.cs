using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Base;

public abstract class NeoComponentBase : ComponentBase
{
    protected virtual Guid Id { get; set; } = Guid.NewGuid();

    [Parameter] 
    public virtual ThemeColor Color { get; set; } = ThemeColor.Primary;

    [Parameter] 
    public virtual ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

    [Parameter] 
    public virtual BackgroundShape Shape { get; set; } = BackgroundShape.Flat;

    [Parameter] 
    public virtual BorderRadius BorderRadius { get; set; } = BorderRadius.Default;

    [Parameter] 
    public virtual Spacing Margin { get; set; } = Spacing._0;
    
    [Parameter]
    public virtual Spacing Padding { get; set; } = Spacing._0;

    // UI Methods
    protected virtual string ColorClass => Color.GetCssClass();
    protected virtual string ShadowClass => ShadowPosition.GetCssClass();
    protected virtual string ShapeClass => Shape.GetCssClass();
    protected virtual string BorderRadiusStyle => BorderRadius.GetCssProperty();
    protected virtual string PaddingClass => Padding.GetCssClass("padding");
    protected virtual string MarginClass => Padding.GetCssClass("margin");
}