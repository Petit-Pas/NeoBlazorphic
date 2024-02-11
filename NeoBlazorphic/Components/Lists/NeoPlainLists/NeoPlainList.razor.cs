using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Models.SelectableItems;

namespace NeoBlazorphic.Components.Lists.NeoPlainLists;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global

// This part of the partial contain any logic
// For parameters, check the .razor.parameters.cs file
public partial class NeoPlainList<T> : ComponentBase
{
    /// <summary>
    ///     Returns an array with the items, filtered using Filter and FilterString
    ///     Returns the whole list if any of Filter or FilterString is not initialized
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

    /// <summary>
    ///     Just subscribe the click event to this method and the communication with the ISelectableItemList is automatically handled
    /// </summary>
    /// <param name="itemClicked"></param>
    protected virtual async Task ItemClicked(T itemClicked)
    {
        if (itemClicked is ISelectableItem item && Items is ISelectableItemList items)
        {
            items.Select(item);
            StateHasChanged();
        }

        await OnElementClickCallBack.InvokeAsync(itemClicked);
    }

    protected virtual string GetSelectedClass(T item) => item?.IsSelected() ?? false ? "selected" : "";

}