using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace NeoBlazorphic.Components.Inputs.Fields;

public partial class NeoBaseInput<T> : InputBase<T>
{
    [Parameter, EditorRequired]
    public Expression<Func<T>> ValidationFor { get; set; } = default!;

    [Parameter]
    public RenderFragment? InputFieldPrefix { get; set; }

    [Parameter]
    public RenderFragment? InputFieldSuffix { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public bool ValidateOnKeyPress { get; set; }

    [Parameter]
    public string AccentColor { get; set; } = "neo-primary";

    // UI Methods
    private string GetInvalid => EditContext.GetValidationMessages(FieldIdentifier).Any() ? "neo-danger" : "";

}