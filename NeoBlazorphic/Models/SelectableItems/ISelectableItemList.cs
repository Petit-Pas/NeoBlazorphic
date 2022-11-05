namespace NeoBlazorphic.Models.SelectableItems;

public interface ISelectableItemList
{
    void ResetSelected(ISelectableItem? selectedItem);
    bool HasSelectedItem(int amount = 1);

    event EventHandler SelectionUpdated;
}