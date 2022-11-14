using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace NeoBlazorphic.Components.Inputs.Fields.BaseFields
{
    public partial class BaseTextField : InputBase<string>
    {
        [Parameter, EditorRequired] public Expression<Func<string>> ValidationFor { get; set; } = default!;
        [Parameter] public string? Label { get; set; }
        [Parameter] public string? Placeholder { get; set; }

        private string Id { get; set; } = Guid.NewGuid().ToString();

        protected override bool TryParseValueFromString(string? value, out string result, out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
