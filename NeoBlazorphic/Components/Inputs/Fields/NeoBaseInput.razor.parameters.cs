using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.Fields;

public partial class NeoBaseInput<T>
{
    /// <summary>
    ///     Same validation for as normal inputs
    /// </summary>
    [Parameter, EditorRequired]
    public virtual Expression<Func<T>> ValidationFor { get; set; } = default!;

    /// <summary>
    ///     small render fragment that can be rendered before the field
    ///     Usually a string
    /// </summary>
    [Parameter]
    public virtual RenderFragment? PrefixRenderFragment { get; set; }

    /// <summary>
    ///     small render fragment that can be rendered after the field
    ///     Usually a string
    /// </summary>
    [Parameter]
    public virtual RenderFragment? SuffixRenderFragment { get; set; }

    /// <summary>
    ///     A label displayed above the field
    /// </summary>
    [Parameter]
    public virtual string? Label { get; set; }

    /// <summary>
    ///     Placeholder for the field
    /// </summary>
    [Parameter]
    public virtual string? Placeholder { get; set; }

    /// <summary>
    ///     Tells to validate on each keypress
    ///     Opposed to on losing focus, default to false
    /// </summary>
    [Parameter]
    public virtual bool ValidateOnKeyPress { get; set; }

    [Parameter]
    public virtual Spacing PrefixPadding { get; set; } = Spacing._2;

    [Parameter]
    public virtual Spacing SuffixPadding { get; set; } = Spacing._2;

    // UI Methods
    protected virtual string InvalidClass => IsInvalid switch
    {
        true => ThemeColor.Danger.GetCssClass(),
        false => ""
    };
}