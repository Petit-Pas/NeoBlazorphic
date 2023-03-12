using System.Collections;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Models.SelectableItems;

namespace NeoBlazorphic.Components.Base;

public abstract class NeoSelectableListComponentBase<T> : NeoComponentBase
{
    /// <summary>
    ///     Should be an IEnumerable of items to select from for any "selection" component
    ///     List components should be able to handle non selectable items as well (for display purpose), in that case a,y IEnumerable should be good
    /// </summary>
    [Parameter, EditorRequired]
    public virtual IEnumerable? Items { get; set; }

    /// <summary>
    ///     This might not be needed, but if the implemented list can display an item however the user wishes, this is the template
    /// </summary>
    [Parameter]
    public virtual RenderFragment<T?>? ItemRenderFragment { get; set; }

    /// <summary>
    ///     If a filter has been provided, this is the string that will be used as the string input to the Func
    ///     Some components might decide to override this and take control of their filters themselves
    /// </summary>
    [Parameter]
    public virtual string FilterString { get; set; } = string.Empty;

    /// <summary>
    ///     This Func provides a custom way to filter using a string to describe any kind of object.
    ///     It can range from a string.Contains to a complex search mode with tags for instance.
    /// </summary>
    [Parameter]
    public Func<T, string, bool>? Filter { get; set; }

    /// <summary>
    ///     Returns an array with the items, filtered using Filter and FilterString
    /// </summary>
    /// <returns></returns>
    protected virtual T[] DisplayableItems()
    {
        if (Items is IEnumerable<T> items)
        {
            if (Filter == null || string.IsNullOrEmpty(FilterString))
            {
                return items.ToArray();
            }
            return items.Where(x => Filter(x, FilterString)).ToArray();
        }
        return Array.Empty<T>();
    }

    protected virtual string GetSelectedClass(T item) => item!.IsSelected() ? "selected" : "";

    /// <summary>
    ///     Just subscribe the click event to this method and the communication with the ISelectableItemList is automatically handled
    /// </summary>
    /// <param name="itemClicked"></param>
    protected virtual void ItemClicked(T itemClicked)
    {
        if (itemClicked is ISelectableItem item && Items is ISelectableItemList items)
        {
            items.Select(item);
            StateHasChanged();
        }
    }


}