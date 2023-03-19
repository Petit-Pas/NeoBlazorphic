using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Components.Inputs.Fields.String
{
    public class StringInput : NeoBaseInput<string>
    {
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value!;
            validationErrorMessage = null;
            return true;
        }
    }
}
