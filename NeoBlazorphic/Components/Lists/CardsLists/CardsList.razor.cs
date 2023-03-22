using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Lists.CardsLists;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class CardsList<T>
{
    protected virtual T[] DisplayableItems()
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

    protected virtual void ItemClicked(T clickedItem)
    {
        if (clickedItem is ISelectableItem item && Items is ISelectableItemList items)
        {
            items.Select(item);
            StateHasChanged();
        }
    }

    protected virtual ThemeColor ColorFor(T item)
    {
        return item?.IsSelected() ?? false ? AccentClass : ThemeColor.Base;
    }
}