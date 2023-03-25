namespace NeoBlazorphic.Models.SelectableItems;

/// <summary>
///     A model class to contain information about item that can be selected, usually among a list
/// </summary>
/// <typeparam name="T"> the type of item that is selectable. That item will be displayed with .ToString, so better make sure that that method is implemented </typeparam>
public class SelectableItem<T> : ISelectableItem
{
    public static readonly SelectableItem<T> Empty = new ();

    private SelectableItem()
    {
        Item = default;
    }

    public SelectableItem(T item, bool isSelected = false)
    {
        Item = item;
        IsSelected = isSelected;
    }

    public bool IsSelected { get; set; } = false;

    /// <summary>
    ///     The actual object to select
    /// </summary>
    public T? Item { get; set; }
}