namespace NeoBlazorphic.Models.SelectableItems;

public interface ISelectableItemList
{
    void Select(ISelectableItem? selectedItem);

    event EventHandler SelectionUpdated;
}