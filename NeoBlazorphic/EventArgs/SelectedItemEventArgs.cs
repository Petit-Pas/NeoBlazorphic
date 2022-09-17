
using NeoBlazorphic.Models.SelectableItems;

namespace NeoBlazorphic.EventArgs;

public class SelectedItemEventArgs<T>
{
    public SelectedItemEventArgs(SelectableItem<T> item)
    {
        Item = item;
    }

    public SelectableItem<T> Item { get; set; }
}