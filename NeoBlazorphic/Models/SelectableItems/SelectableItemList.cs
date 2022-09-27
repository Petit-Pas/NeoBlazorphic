using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace NeoBlazorphic.Models.SelectableItems;

public class SelectableItemList<T> : List<SelectableItem<T>>
{
    public static readonly SelectableItemList<T> Empty = new ();

    public bool HasSelectedItem(int amount = 1)
    {
        return this.Count(x => x.IsSelected) == amount;
    }

    public void ResetSelected(SelectableItem<T>? selectedItem)
    {
        if (WarnIfNull(selectedItem) || WarnIfNotInCollection(selectedItem))
        {
            return;
        }

        foreach (var item in this)
        {
            item.IsSelected = item == selectedItem;
        }
    }

    private bool WarnIfNull([NotNullWhen(false)] SelectableItem<T>? item)
    {
        if (item != null)
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with SelectableItemList with a null item");
        return true;
    }

    private bool WarnIfNotInCollection(SelectableItem<T> item)
    {
        if (this.Contains(item))
        {
            return false;
        }

        Console.WriteLine("Error: trying to interact with SelectableItemList with an item that does not belong to the collection");
        return true;
    }
}