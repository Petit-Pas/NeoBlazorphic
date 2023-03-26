using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.Extensions.BaseTypes;

namespace NeoBlazorphic.Components.Inputs.Checks.CheckBoxes;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class CheckBox
{
    /// <summary>
    ///     Property to bind to for the check
    /// </summary>
    [Parameter]
    public virtual bool IsChecked { get; set; }

    /// <summary>
    ///     Event used for the IsChecked propertyBinding
    /// </summary>
    [Parameter]
    public virtual EventCallback<bool> IsCheckedChanged { get; set; }

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
    public virtual CheckBoxShape BoxShape { get; set; } = CheckBoxShape.Squared;

    /// <summary>
    ///     Tells if the checkbox should be enabled
    /// </summary>
    [Parameter]
    public virtual bool IsEnabled { get; set; } = true;

    // UI methods
    protected virtual string CheckedClass => IsChecked switch
    {
        true => "checked",
        false => "unchecked"
    };
    protected virtual string ShadowClass => IsChecked switch
    {
        true => ShadowPosition.In.GetCssClass(),
        false => ShadowPosition.Out.GetCssClass(),
    };
    protected virtual string ColorClass => IsChecked switch
    {
        true => Color.GetCssClass(),
        false => ThemeColor.Base.GetCssClass(),
    };
    protected virtual string CheckBoxShapeClass => BoxShape.GetCssClass();
    protected virtual string EnabledClass => IsEnabled switch
    {
        true => "enabled",
        false => "disabled",
    };
    protected virtual string BgShapeClasses => IsEnabled switch
    {
        true => "neo-flat neo-concave-on-hover",
        false => "neo-flat"
    };
    protected virtual string ImageShapePath => BoxShape switch
    {
        CheckBoxShape.Squared => "_content/NeoBlazorphic/img/check.png",
        CheckBoxShape.Round => "_content/NeoBlazorphic/img/dot.png",
        _ => throw new NotImplementedException($"The CheckBoxShape {BoxShape} is not handled")
    };
}