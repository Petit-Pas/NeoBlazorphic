using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.Extensions.BaseTypes;

namespace NeoBlazorphic.Components.Base.Cards
{
    public partial class NewCard : ComponentBase
    {
        [Parameter]
        public RenderFragment? Body { get; set; }

        [Parameter]
        public ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

        [Parameter] 
        public ColorTheme ColorTheme { get; set; } = ColorTheme.Primary;

        [Parameter] 
        public BackgroundShape BackgroundShape { get; set; } = BackgroundShape.Flat;

        [Parameter] 
        public BorderRadius BorderRadius { get; set; } = BorderRadius.Default;

        [Parameter] public bool SelectableText { get; set; } = false;

        // UI Methods
        public string GetShadowPositionClass => ShadowPosition.GetCssClass().Split("-").Last();

        public string GetColorTheme => ColorTheme.GetCssClass();

        public string GetBackgroundShape => "neo-" + BackgroundShape.GetCssClass();

        public string GetSelectableText => SelectableText ? "" : "prevent-select";
    }
}