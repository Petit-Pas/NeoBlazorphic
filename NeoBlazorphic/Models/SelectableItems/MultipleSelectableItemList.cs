namespace NeoBlazorphic.Models.SelectableItems;

public class MultipleSelectableItemList<T> : BaseSelectableList<T>, ISelectableItemList
{
    private int _maxSelected;

    /// <summary>
    ///     Ctor    
    /// </summary>
    /// <param name="maxSelected"> The maximum amount of selected items, -1 for no boundaries </param>
    public MultipleSelectableItemList(int maxSelected = -1)
    {
        _maxSelected = maxSelected;
    }

    public void Select(ISelectableItem? selectedItem)
    {
        // Error
        if (WarnIfNull(selectedItem) || WarnIfNotInCollection(selectedItem))
        {
            return;
        }

        if (selectedItem.IsSelected)
        {
            selectedItem.IsSelected = false;
            OnSelectionUpdated();
        }
        else if (_maxSelected == -1 || this.Count(x => x.IsSelected) < _maxSelected)
        {
            selectedItem.IsSelected = true;
            OnSelectionUpdated();
        }
    }
}