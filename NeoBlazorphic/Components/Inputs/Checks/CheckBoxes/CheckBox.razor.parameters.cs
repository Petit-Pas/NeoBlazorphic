using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.Extensions.BaseTypes;

namespace NeoBlazorphic.Components.Inputs.Checks.CheckBoxes;

public partial class CheckBox : ComponentBase
{
    /// <summary>
    ///     Accent color of the checkbox
    ///     Only visible when checked
    /// </summary>
    [Parameter]
    public virtual ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    ///     Shape of the checkbox
    ///     Will also impact the shape of the tick
    /// </summary>
    [Parameter]
    public CheckBoxShape BoxShape { get; set; } = CheckBoxShape.Squared;

    /// <summary>
    ///     Property to bind to for the check
    /// </summary>
    [Parameter]
    public bool IsChecked { get; set; }

    /// <summary>
    ///     Event used for the IsChecked propertyBinding
    /// </summary>
    [Parameter]
    public EventCallback<bool> IsCheckedChanged { get; set; }

    /// <summary>
    ///     Tells if the checkbox should be enabled
    /// </summary>
    [Parameter]
    public bool IsEnabled { get; set; }

    // UI methods
    protected virtual string CheckedClass => IsChecked ? "checked" : "unchecked";
    protected virtual string ShadowClass => IsChecked ? "neo-shadow-in" : "neo-shadow-out";
    protected virtual string ColorClass => IsChecked ? Color.GetCssClass() : ThemeColor.Base.GetCssClass();
    protected virtual string ShapeClass => BoxShape.GetCssClass();
    protected virtual string EnabledClass => IsEnabled ? "enabled" : "disabled";
    protected virtual string GetBgShape => "neo-flat" + (IsEnabled ? " neo-concave-on-hover" : "");

    protected virtual string ShapeImage => BoxShape switch
    {
        CheckBoxShape.Squared => "_content/NeoBlazorphic/img/check.png",
        CheckBoxShape.Round => "_content/NeoBlazorphic/img/dot.png",
        _ => throw new NotImplementedException($"The CheckBoxShape {BoxShape} is not handled")
    };

}