using System.Collections;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Lists.PlainLists
{
    public partial class PlainList<T> : ComponentBase
    {
        [Parameter, EditorRequired]
        public IEnumerable? Items { get; set; }

        [Parameter]
        public RenderFragment<T?>? ItemRenderFragment { get; set; }

        [Parameter]
        public string AccentClass { get; set; } = "";

        [Parameter] 
        public ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

        [Parameter]
        public Func<T, string, bool>? Filter { get; set; }

        [Parameter] 
        public string FilterString { get; set; } = "";

        private T[] DisplayableItems()
        {
            if (Items is IEnumerable<T> items)
            {
                if (Filter == null || string.IsNullOrEmpty(FilterString))
                {
                    return items.ToArray();
                }
                return items.Where(x => Filter(x, FilterString)).ToArray();
            }
            return Array.Empty<T>();
        }

        private void ItemClicked(T itemClicked)
        {
            if (itemClicked is ISelectableItem item && Items is ISelectableItemList items)
            {
                items.ResetSelected(item);
                StateHasChanged();
            }
        }
    }
}
