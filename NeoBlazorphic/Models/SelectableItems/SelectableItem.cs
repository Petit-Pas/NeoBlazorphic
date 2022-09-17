namespace NeoBlazorphic.Models.SelectableItems;

/// <summary>
///     A model class to contain information about item that can be selected, usually among a list
/// </summary>
/// <typeparam name="T"> the type of item that is selectable. That item will be displayed with .ToString, so better make sure that that method is implemented </typeparam>
public class SelectableItem<T>
{
    public readonly static SelectableItem<T> Empty = new ();

    private SelectableItem()
    {
    }

    public SelectableItem(T item, int index, bool isEnabled = true, bool isSelected = false)
    {
        Item = item;
        Index = index;
        IsEnabled = isEnabled;
        IsSelected = isSelected;
    }

    /// <summary>
    ///     If for some reason you want a value to be displayed in the same list as others, but you don't want it to be selectable'
    /// </summary>
    public bool IsEnabled { get; set; } = true;

    public bool IsSelected { get; set; } = false;

    /// <summary>
    ///     The actual object to select
    /// </summary>
    public T Item { get; set; }

    /// <summary>
    ///     Will be used by any UI component to actually display the actual Item.
    /// </summary>
    public string Label => Item?.ToString() ?? "item has no label or is empty";

    /// <summary>
    ///     The index of this specific item among the list in which he resides.
    /// </summary>
    public int Index { get; set; }
}