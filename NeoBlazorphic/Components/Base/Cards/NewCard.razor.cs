using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.Extensions.BaseTypes;
using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Base.Cards
{
    public partial class NewCard : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

        [Parameter] 
        public ColorTheme ColorTheme { get; set; } = ColorTheme.Base;

        [Parameter]
        public BackgroundShape BackgroundShape { get; set; } = BackgroundShape.Flat;

        [Parameter] 
        public BorderRadius BorderRadius { get; set; } = BorderRadius.Default;

        [Parameter] public bool SelectableText { get; set; } = false;

        [Parameter] public string AdditionalClasses { get; set; } = "";

        [Parameter]
        public Spacing Padding { get; set; } = Spacing._3;
        [Parameter]
        public Spacing Margin { get; set; } = Spacing._0;

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseClickCallBack { get; set; }


        protected async Task OnClick(MouseEventArgs args)
        {
            await OnMouseClickCallBack.InvokeAsync(args);
        }

        // UI Methods
        public string GetShadowPositionClass => ShadowPosition.GetCssClass();

        public string GetColorTheme => ColorTheme.GetCssClass();

        public string GetBackgroundShape => BackgroundShape.GetCssClass();

        public string GetSelectableText => SelectableText ? "" : "prevent-select";

        private string GetPadding => Padding.GetCssClass("padding");
        private string GetMargin => Margin.GetCssClass("margin");
    }
}