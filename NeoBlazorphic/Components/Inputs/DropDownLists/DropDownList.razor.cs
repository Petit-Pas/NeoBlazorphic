using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Models.SelectableItems;

namespace NeoBlazorphic.Components.Inputs.DropDownLists
{
	public partial class DropDownList<T> : UiComponentBase
    {
        [Parameter, EditorRequired]
        public SelectableItemList<T> Items { get; set; } = SelectableItemList<T>.Empty;
    }
}
