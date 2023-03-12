using NeoBlazorphic.Models.SelectableItems;

namespace NeoBlazorphic.Extensions.BaseTypes;

public static class ObjectExtensions
{
    public static bool IsSelected(this object obj)
    {
        if (obj is ISelectableItem selectableItem)
        {
            return selectableItem.IsSelected;
        }
        // If the item displayed is not contained in a SelectableItem, then the item is not considered selectable, hence not selected
        return false;
    }
}