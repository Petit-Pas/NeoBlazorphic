using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.StyleParameters;
using System.Globalization;

namespace NeoBlazorphic.Components.Inputs.Fields
{
    public partial class NeoBaseInput<T>
    {
        protected virtual string Id { get; set; } = Guid.NewGuid().ToString();

        protected virtual bool IsInvalid => EditContext.GetValidationMessages(FieldIdentifier).Any();

        protected virtual void OnFocusIn(FocusEventArgs e)
        {
            IsFocused = true;
            StateHasChanged();
        }

        protected virtual void OnFocusOut(FocusEventArgs e)
        {
            IsFocused = false;
            StateHasChanged();
        }

        protected virtual bool IsFocused { get; set; } = false;


        // UI computing methods 

        private const int CornerRemSize = 4;
        private static readonly BorderRadius _full = new(CornerRemSize, "rem");
        private static readonly BorderRadius _squaredOnLeft = new(0, CornerRemSize, CornerRemSize, 0, "rem");
        private static readonly BorderRadius _squaredOnRight = new(CornerRemSize, 0, 0, CornerRemSize, "rem");
        private static readonly BorderRadius _squared = new(0);
        
        private BorderRadius GetFieldBorderRadius()
        {
            return (PrefixRenderFragment != null, SuffixRenderFragment != null) switch
            {
                (true, true) => _squared,
                (false, false) => _full,
                (false, true) => _squaredOnRight,
                (true, false) => _squaredOnLeft
            };
        }

        private EventCallback<ChangeEventArgs> GetOnInputBinder()
        {
            /*
                This oninput rule serves the purpose of both triggering the onchange event AND the validation on each keystroke.
                https://www.meziantou.net/validating-an-input-on-keypress-instead-of-on-change-in-blazor.htm
            */

            if (ValidateOnKeyPress)
            {
                return EventCallback.Factory.CreateBinder<string?>(this, value => CurrentValueAsString = value,
                    CurrentValueAsString!);
            }
            return default;
        }

        private EventCallback<ChangeEventArgs> GetOnChangeBinder()
        {
            /*
                This oninput rule serves the purpose of both triggering the onchange event AND the validation on each keystroke.
                https://www.meziantou.net/validating-an-input-on-keypress-instead-of-on-change-in-blazor.htm
            */

            if (!ValidateOnKeyPress)
            {
                return EventCallback.Factory.CreateBinder<string?>(this, value => CurrentValueAsString = value,
                    CurrentValueAsString!);
            }
            return default;
        }

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out T result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = default;
            validationErrorMessage = "NeoBaseInput implementations should override TryParseValueFromString()";
            return false;
        }

        protected override string? FormatValueAsString(T? value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            return value switch
            {
                null => null,
                string @string => @string,
                int @int => BindConverter.FormatValue(@int, CultureInfo.InvariantCulture),
                long @long => BindConverter.FormatValue(@long, CultureInfo.InvariantCulture),
                short @short => BindConverter.FormatValue(@short, CultureInfo.InvariantCulture),
                float @float => BindConverter.FormatValue(@float, CultureInfo.InvariantCulture),
                double @double => BindConverter.FormatValue(@double, CultureInfo.InvariantCulture),
                decimal @decimal => BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture),
                _ => throw new InvalidOperationException($"Unsupported type {value.GetType()}")
            };
        }
    }
}
