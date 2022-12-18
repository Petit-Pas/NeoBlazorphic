using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.StyleParameters;
using System.Globalization;

namespace NeoBlazorphic.Components.Inputs.Fields
{
    public partial class NeoBaseInput<T> : InputBase<T>
    {
        [Parameter, EditorRequired] public Expression<Func<T>> ValidationFor { get; set; } = default!;
        [Parameter] public string? Label { get; set; }
        [Parameter] public string? Placeholder { get; set; }
        [Parameter] public bool ValidateOnKeyPress { get; set; }
        [Parameter] public int LabelSizePx { get; set; } = 100;
        [Parameter] public ElementRelativePosition LabelPosition { get; set; } = ElementRelativePosition.Top;
        [Parameter] public string AccentColor { get; set; } = "neo-primary";

        private bool IsFocused { get; set; } = false;

        private string Id { get; set; } = Guid.NewGuid().ToString();

        private bool IsHovered { get; set; } = false;

        private bool IsValid { get; set; } = true;

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out T result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            IsValid = true;
            if (EditContext.GetValidationMessages(FieldIdentifier).Any())
            {
                IsValid = false;
            }

            // those values should not be used anyway, this class should always be used by overriding and calling base method
            result = default;
            validationErrorMessage = null;
            return IsValid;
        }

        protected override string? FormatValueAsString(T? value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            switch (value)
            {
                case null:
                    return null;

                case string @string:
                    return @string;

                case int @int:
                    return BindConverter.FormatValue(@int, CultureInfo.InvariantCulture);

                case long @long:
                    return BindConverter.FormatValue(@long, CultureInfo.InvariantCulture);

                case short @short:
                    return BindConverter.FormatValue(@short, CultureInfo.InvariantCulture);

                case float @float:
                    return BindConverter.FormatValue(@float, CultureInfo.InvariantCulture);

                case double @double:
                    return BindConverter.FormatValue(@double, CultureInfo.InvariantCulture);

                case decimal @decimal:
                    return BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture);

                default:
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }

        private void OnFocusIn(FocusEventArgs e)
        {
            IsFocused = true;
            StateHasChanged();
        }

        private void OnFocusOut(FocusEventArgs e)
        {
            IsFocused = false;
            StateHasChanged();
        }

        private void OnMouseOver()
        {
            IsHovered = true;
        }

        private void OnMouseOut()
        {
            IsHovered = false;
        }

        // UI computing methods 
        private string GetColumnDefinition()
        {
            return LabelPosition switch
            {
                ElementRelativePosition.Left => $"grid-template-columns: {LabelSizePx}px 1fr;",
                ElementRelativePosition.Right => $"grid-template-columns: 1fr {LabelSizePx}px;",
                _ => "grid-template-columns: 1fr;"
            };
        }

        private string GetRowDefinition()
        {
            return LabelPosition switch
            {
                ElementRelativePosition.Top => "grid-template-rows: auto, auto",
                ElementRelativePosition.Bottom => "grid-template-rows: auto, auto",
                _ => "grid-template-rows: auto;"
            };
        }

        private string GetLabelGridPositions()
        {
            var row = LabelPosition is ElementRelativePosition.Bottom ? 2 : 1;
            var col = LabelPosition is ElementRelativePosition.Right ? 2 : 1;

            return $"grid-row: {row}; grid-column: {col};";
        }

        private string GetFieldGridPositions()
        {
            var row = LabelPosition is ElementRelativePosition.Top ? 2 : 1;
            var col = LabelPosition is ElementRelativePosition.Left ? 2 : 1;

            return $"grid-row: {row}; grid-column: {col};";
        }

        private string GetAccentColor()
        {
            return IsValid ? "" : "neo-danger";
        }

        private static readonly int _cornerRemSize = 4;
        private static readonly BorderRadius _full = new(_cornerRemSize, "rem");
        private static readonly BorderRadius _squaredOnRight = new(0, _cornerRemSize, _cornerRemSize, 0, "rem");
        private static readonly BorderRadius _squaredOnLeft = new(_cornerRemSize, 0, 0, _cornerRemSize, "rem");

        private BorderRadius GetFieldBorderRadius()
        {
            return LabelPosition switch
            {
                ElementRelativePosition.Left => _squaredOnRight,
                ElementRelativePosition.Right => _squaredOnLeft,
                _ => _full
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

        private string GetInputAccentClass() => IsFocused ? AccentColor : "";
    }
}
