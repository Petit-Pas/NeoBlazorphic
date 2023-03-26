using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class CircularSelector<T> : ComponentBase
{
    /// <summary>
    ///     Should be a list of CircularSelectorButtonContent
    ///     They will interact with the CircularSelector by themselves
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent
    {
        get => _childContent;
        set
        {
            if (value != _childContent)
            {
                ButtonContents.Clear();
                _childContent = value;
            }
        }
    }
    private RenderFragment? _childContent = null;

    /// <summary>
    ///     An offset in degrees to rotate the buttons
    /// </summary>
    [Parameter]
    public int AngleOffset { get; set; } = 0;

    /// <summary>
    ///     Overall shape of the component
    ///     Should be Concave or Convex, no Flat
    /// </summary>
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