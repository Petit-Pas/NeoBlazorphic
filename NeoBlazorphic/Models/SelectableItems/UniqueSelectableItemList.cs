using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Models.SelectableItems;

/// <summary>
///     A list that will only accept 1 selected item at a time
///     Selecting an item already selected will unselect it
/// </summary>
/// <typeparam name="T"></typeparam>
public class UniqueSelectableItemList<T> : List<SelectableItem<T>>, ISelectableItemList
{
    public static readonly UniqueSelectableItemList<T> Empty = new();

    public event EventHandler? SelectionUpdated;

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

    private void OnSelectionUpdated()
    {
        SelectionUpdated?.Invoke(this, System.EventArgs.Empty);
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

    private bool WarnIfNull([NotNullWhen(false)] ISelectableItem? item)
    {
        if (item != null)
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with UniqueSelectableItemList with a null item");
        return true;
    }

    private bool WarnIfNotInCollection(ISelectableItem item)
    {
        if (this.Contains(item))
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with UniqueSelectableItemList with an item that does not belong to the collection");
        return true;
    }
}