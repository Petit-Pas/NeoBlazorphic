using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Models.SelectableItems;

/// <summary>
///     A list that will only accept 1 selected item at a time
///     Selecting an item already selected will unselect it
/// </summary>
/// <typeparam name="T"></typeparam>
public class UniqueSelectableItemList<T> : BaseSelectableList<T>, ISelectableItemList
{
    public void Select(ISelectableItem? selectedItem)
    {
        // Error
        if (WarnIfNull(selectedItem) || WarnIfNotInCollection(selectedItem))
        {
            return;
        }

        // Already selected => unselect
        if (SelectedItem == selectedItem)
        {
            selectedItem.IsSelected = false;
            SelectedItem = null;
            return;
        }

        // Updates selection
        foreach (var item in this)
        {
            item.IsSelected = item == selectedItem;
        }

        SelectedItem = selectedItem;
    }

    private ISelectableItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (_selectedItem != value)
            {
                _selectedItem = value;
                OnSelectionUpdated();
            }
        }
    }
    private ISelectableItem? _selectedItem;
}