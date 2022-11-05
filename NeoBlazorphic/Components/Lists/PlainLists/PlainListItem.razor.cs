using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Lists.PlainLists
{
    public partial class PlainListItem<T> : MouseInteractiveBaseComponent
    {
        [Parameter, EditorRequired]
        public T? Item { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment<T?>? ItemRenderFragment { get; set; }

        [Parameter, EditorRequired]
        public int ItemIndex { get; set; }

        [Parameter]
        public string AccentClass { get; set; } = "";
        
        protected override void StateUpdated()
        {
            base.StateUpdated();
            StateHasChanged();
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
        public string GetBrightnessFilter()
        {
            if (IsSelected() || IsHovered)
            {
                return "backdrop-filter: brightness(100%);";
            }
            return ItemIndex % 2 == 0 ? "backdrop-filter: brightness(80%);" : "backdrop-filter: brightness(125%);";
        }

        public string GetBackgroundColor() =>
            IsSelected()
                ? "background: var(--dark-color)"
                : IsHovered
                    ? "background: var(--light-color)"
                    : "";
    }
}
