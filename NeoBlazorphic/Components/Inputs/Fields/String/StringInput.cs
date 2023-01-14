using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Components.Inputs.Fields.String
{
    public class StringInput : NeoBaseInput<string>
    {
        [CascadingParameter]
        protected EditContext EditContext { get; set; }


        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value!;
            validationErrorMessage = null;
            return true;
        }
    }
}
