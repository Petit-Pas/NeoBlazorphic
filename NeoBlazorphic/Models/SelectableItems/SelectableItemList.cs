using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Models.SelectableItems;

public interface ISelectableItemList
{
    void ResetSelected(ISelectableItem? selectedItem);
    bool HasSelectedItem(int amount = 1);

    event EventHandler SelectionUpdated;
}

public class SelectableItemList<T> : List<SelectableItem<T>>, ISelectableItemList
{
    public static readonly SelectableItemList<T> Empty = new();

    public event EventHandler SelectionUpdated;

    public bool HasSelectedItem(int amount = 1)
    {
        return this.Count(x => x.IsSelected) == amount;
    }

    public void ResetSelected(ISelectableItem? selectedItem)
    {
        if (WarnIfNull(selectedItem) || WarnIfNotInCollection(selectedItem))
        {
            return;
        }

        if (SelectedItem != null && selectedItem == SelectedItem)
        {
            return;
        }

        foreach (var item in this)
        {
            item.IsSelected = item == selectedItem;
        }

        SelectedItem = selectedItem;
    }

    private void OnSelectionUpdated()
    {
        SelectionUpdated?.Invoke(this, new System.EventArgs());
    }

    public ISelectableItem? SelectedItem
    {
        get => selectedItem;
        set
        {
            if (selectedItem == value)
            {
                selectedItem = value;
                OnSelectionUpdated();
            }
        }
    }
    private ISelectableItem? selectedItem;

    private bool WarnIfNull([NotNullWhen(false)] ISelectableItem? item)
    {
        if (item != null)
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with SelectableItemList with a null item");
        return true;
    }

    private bool WarnIfNotInCollection(ISelectableItem item)
    {
        if (this.Contains(item))
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with SelectableItemList with an item that does not belong to the collection");
        return true;
    }

}