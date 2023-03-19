using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

public partial class CircularSelector : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;

    [Parameter]
    public int AngleOffset { get; set; } = 0;

    [Parameter]
    public BackgroundShape Shape
    {
        get => _shape;
        set
        {
            if (_shape == value)
            {
                return;
            }
            if (value != BackgroundShape.Concave && value != BackgroundShape.Convex)
            {
                Console.WriteLine($"WARNING: CircularSelector.Shape cannot be {Enum.GetName(value)}. Try with {Enum.GetName(BackgroundShape.Concave)} or {Enum.GetName(BackgroundShape.Convex)}");
                return;
            }
            _shape = value;
            StateHasChanged();
        }
    }
    private BackgroundShape _shape = BackgroundShape.Concave;

    [Parameter]
    public int ButtonAngle { get; set; } = 30;

    [Parameter]
    public virtual ThemeColor ThemeColor { get; set; } = ThemeColor.Base;
    [Parameter]
    public virtual ThemeColor Selected { get; set; } = ThemeColor.Primary;

    [Parameter]
    public virtual string? CenterText { get; set; }


    // UI Methods
    protected virtual string ColorClass => ThemeColor.GetCssClass();
    protected virtual string ShapeClass => Shape.GetCssClass();
}