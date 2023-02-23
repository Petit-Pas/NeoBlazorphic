using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.Checks.CheckBoxes
{
    public partial class NewCheckBox : ComponentBase
    {
        [Parameter]
        public bool IsEnabled { get; set; }

        [Parameter]
        public CheckBoxShape BoxShape { get; set; } = CheckBoxShape.Normal;

        [Parameter]
        public bool IsChecked { get; set; }

        [Parameter]
        public EventCallback<bool> IsCheckedChanged { get; set; }

        [Parameter]
        public ColorTheme ColorTheme { get; set; } = ColorTheme.Base;

        private async Task OnMouseClick(MouseEventArgs args)
        {
            if (IsEnabled)
            {
                IsChecked = !IsChecked;
                await IsCheckedChanged.InvokeAsync(IsChecked);
            }
        }

        // Ui methods
        private string GetChecked => IsChecked ? "checked" : "unchecked";
        private string GetShadow => IsChecked ? "neo-shadow-in" : "neo-shadow-out";
        private string GetColorTheme => IsChecked ? ColorTheme.GetCssClass() : "neo-base";

        private string GetBgShape => "neo-flat" + (IsEnabled ? " neo-concave-on-hover" : "");

        // TODO this should change with the enum when getting rid of the old code
        private string GetShape => BoxShape == CheckBoxShape.Normal ? "squared" : "circled"; 

        private string GetEnabled => IsEnabled ? "enabled" : "disabled";
        private string GetShapeImage => BoxShape == CheckBoxShape.Normal ? "_content/NeoBlazorphic/img/check.png" : "_content/NeoBlazorphic/img/dot.png";

    }
}
