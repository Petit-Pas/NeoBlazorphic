using System.Collections;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Models.SelectableItems;
using System.Linq;

namespace NeoBlazorphic.Components.Lists.CardsLists
{
    public partial class CardsList<T>
    {

        [Parameter, EditorRequired]
        public IEnumerable? Items { get; set; }

        [Parameter]
        public RenderFragment<T>? ItemRenderFragment { get; set; }

        [Parameter]
        public RenderFragment? FooterRenderFragment { get; set; }

        [Parameter]
        public string? AccentClass { get; set; }

        [Parameter]
        public Func<T, string, bool>? Filter { get; set; }

        public string? SearchBarQuery
        {
            get => _searchBarQuery;
            set => _searchBarQuery = value;
        }
        private string? _searchBarQuery = "";

        private T[] DisplayableItems()
        {
            if (Items is IEnumerable<T> items)
            {
                if (Filter == null || string.IsNullOrEmpty(SearchBarQuery))
                {
                    return items.ToArray();
                }
                return items.Where(x => Filter(x, SearchBarQuery)).ToArray();
            }
            return Array.Empty<T>();
        }

        private void CardClicked(T itemClicked)
        {
            if (itemClicked is ISelectableItem item && Items is ISelectableItemList items)
            {
                items.ResetSelected(item);
                StateHasChanged();
            }
        }
    }
}
