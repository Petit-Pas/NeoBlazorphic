namespace NeoBlazorphic.Components.Inputs.Fields.String
{
    public class StringInput : NeoBaseInput<string>
    {
        protected override bool TryParseValueFromString(string? value, out string result, out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
