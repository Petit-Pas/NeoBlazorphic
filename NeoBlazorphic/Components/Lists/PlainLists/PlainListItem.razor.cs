using Microsoft.AspNetCore.Components;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Lists.PlainLists
{
    public partial class PlainListItem<T> : MouseInteractiveBaseComponent
    {
        [Parameter, EditorRequired]
        public T? Item { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment<T?>? ItemRenderFragment { get; set; }

        [Parameter, EditorRequired]
        public int ItemIndex { get; set; }

        [Parameter]
        public string AccentClass { get; set; } = "";

        // UI Methods
        public string GetBrightnessFilter()
        {
            return ItemIndex % 2 == 0 ? "backdrop-filter: brightness(80%);" : "backdrop-filter: brightness(125%);";
        }
    }
}
