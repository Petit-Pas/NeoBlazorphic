using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

public partial class CircularSelectorButton<T> : ComponentBase
{
    /// <summary>
    ///     the pathstring to use for the path component of the SVG 
    /// </summary>
    [Parameter]
    public virtual string PathString { get; set; } = "";

    /// <summary>
    ///     the shift from the origin to apply to this button
    /// </summary>
    [Parameter]
    public virtual int AngleShift { get; set; } = 0;

    /// <summary>
    ///     what needs to be displayed in the button
    /// </summary>
    [Parameter, EditorRequired]
    public virtual CircularSelectorButtonContent<T>? ButtonContent { get; set; } = null;

    /// <summary>
    ///     Used to dinamically calculate the position of the label on the button
    /// </summary>
    [Parameter, EditorRequired]
    public virtual int ButtonAngle { get; set; }

    /// <summary>
    ///     Shape of the button, should be either Concave or Convex
    /// </summary>
    [Parameter]
    public virtual BackgroundShape Shape
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
                Console.WriteLine($"WARNING: CircularSelectorButton.Shape cannot be {Enum.GetName(value)}. Try with {BackgroundShape.Concave} or {BackgroundShape.Convex}");
            }
            _shape = value;
            StateHasChanged();
        }
    }
    private BackgroundShape _shape = BackgroundShape.Concave;

    /// <summary>
    ///     Color theme of the a selected button
    /// </summary>
    [Parameter]
    public virtual ThemeColor SelectedTheme { get; set; } = ThemeColor.Primary;


    // UI Methods
    protected virtual bool Selected => ButtonContent?.Item?.IsSelected() ?? false;
        
    protected virtual string SelectedThemeClass => Selected ? SelectedTheme.GetCssClass() : "";

    protected virtual string ShapeClass => Shape.GetCssClass();

    protected virtual string SelectedClass => Selected ? "selected" : "";

    protected virtual string ContentSelectedClass => Selected ? ButtonContent?.SelectedClass ?? "" : "";

    protected virtual string ContentAdditionalClass => ButtonContent?.AdditionalClass ?? "";

    protected virtual string EnabledClass => ButtonContent?.Disabled ?? false ? "disabled" : "";

    protected virtual string PointerClass => (ButtonContent?.Disabled ?? false ? Cursor.Default : Cursor.Pointer).GetCssClass();
}