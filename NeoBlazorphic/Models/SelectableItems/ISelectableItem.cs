namespace NeoBlazorphic.Models.SelectableItems;

public interface ISelectableItem
{
    bool IsSelected { get; set; }
    bool IsEnabled { get; set; }
    int Index { get; set; }
}