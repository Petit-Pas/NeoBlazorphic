using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
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
        public RenderFragment<T?>? ItemRenderFragment { get; set; }

        [Parameter]
        public ColorTheme AccentClass { get; set; } = ColorTheme.Primary;

        [Parameter]
        public BorderRadius CardBorderRadius { get; set; } = BorderRadius.Default;


        private BackgroundShape CardShape { get; set; } = BackgroundShape.Flat;

        private ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

        protected override void StateUpdated()
        {
            base.StateUpdated();
            RefreshUIVariables();
        }

        private void RefreshUIVariables()
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
            ShadowPosition = ShadowPosition.Out;
        }

        private bool IsSelectable()
        {
            return Item is ISelectableItem;
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
        private ColorTheme GetAccentClass()
        {
            return IsSelected() ? AccentClass : ColorTheme.Base;
        }
    }
}
