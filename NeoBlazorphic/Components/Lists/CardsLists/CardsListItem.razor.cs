using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Models.SelectableItems;
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

        [Parameter]
        public string AccentClass { get; set; } = "";

        private BackgroundShape CardShape { get; set; } = BackgroundShape.Flat;

        private ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

        protected override void StateUpdated()
        {
            base.StateUpdated();
            ComputeUIVariables();
        }

        private void ComputeUIVariables()
        {
            ComputeShadowPosition();
            ComputeShape();
        }

        private void ComputeShape()
        {
            CardShape = IsHovered switch
            {
                true when !IsSelected() => BackgroundShape.Concave,
                _ => BackgroundShape.Flat
            };
        }

        private void ComputeShadowPosition()
        {
            ShadowPosition = IsSelected() ? ShadowPosition.None : ShadowPosition.Out;
        }

        private bool IsSelected()
        {
            if (Item is ISelectableItem item)
            {
                return item.IsSelected;
            }
            // If the item displayed is not contained in a SelectableItem, then the item is not considered selectable, hence not selected
            return false;
        }

        // UI Methods
        private string GetAccentClass()
        {
            return IsSelected() ? AccentClass : "";
        }
    }
}
