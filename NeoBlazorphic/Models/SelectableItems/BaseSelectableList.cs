using System.Diagnostics.CodeAnalysis;

namespace NeoBlazorphic.Models.SelectableItems;

public abstract class BaseSelectableList<T> : List<SelectableItem<T>>
{
    public event EventHandler? SelectionUpdated;

    protected virtual void OnSelectionUpdated()
    {
        SelectionUpdated?.Invoke(this, System.EventArgs.Empty);
    }

    protected virtual bool WarnIfNull([NotNullWhen(false)] ISelectableItem? item)
    {
        if (item != null)
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with UniqueSelectableItemList with a null item");
        return true;
    }

    protected virtual bool WarnIfNotInCollection(ISelectableItem item)
    {
        if (this.Contains(item))
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with UniqueSelectableItemList with an item that does not belong to the collection");
        return true;
    }
}