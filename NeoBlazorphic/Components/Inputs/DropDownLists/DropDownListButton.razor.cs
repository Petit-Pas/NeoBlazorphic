using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Inputs.DropDownLists
{
    public partial class DropDownListButton<T> : MouseInteractiveBaseComponent
    {
        [Parameter, EditorRequired]
        public SelectableItem<T> Item { get; set; } = SelectableItem<T>.Empty;
    }
}
