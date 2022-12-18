using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Components.Inputs.Fields.Number
{
    public class IntInput : NeoBaseInput<int>
    {
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out int result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            base.TryParseValueFromString(value, out result, out validationErrorMessage);

            validationErrorMessage = null;
            if (int.TryParse(value, out result))
            {
                EditContext.NotifyFieldChanged(FieldIdentifier);
                return true;
            }
            validationErrorMessage = "Please, enter a valid number";
            return false;
        }
    }
}
