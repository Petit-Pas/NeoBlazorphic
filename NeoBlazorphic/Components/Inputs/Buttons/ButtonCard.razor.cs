using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.Buttons
{
    public partial class ButtonCard : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public ColorTheme ColorTheme { get; set; } = ColorTheme.Base;

        [Parameter]
        public BorderRadius BorderRadius { get; set; } = BorderRadius.Default;

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseClickCallBack { get; set; }

        protected virtual async Task OnMouseClick(MouseEventArgs args)
        {
            await OnMouseClickCallBack.InvokeAsync(args);
        }

        // UI Methods
        private string GetColorTheme => ColorTheme.GetCssClass();
    }
}
