using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Lists.CardsLists
{
    public partial class CardsListItem<T> : MouseInteractiveBaseComponent
    {
        [Parameter, EditorRequired]
        public T? Item { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment<T>? ItemRenderFragment { get; set; }

        private BackgroundShape CardShape { get; set; } = BackgroundShape.Flat;

        protected override Task OnMouseOver(MouseEventArgs args)
        {
            CardShape = BackgroundShape.Concave;
            return base.OnMouseOver(args);
        }

        protected override Task OnMouseOut(MouseEventArgs args)
        {
            CardShape = BackgroundShape.Flat;
            return base.OnMouseOut(args);
        }
    }
}
