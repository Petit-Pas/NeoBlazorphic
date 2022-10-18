using Microsoft.AspNetCore.Components;

namespace NeoBlazorphic.Components.Lists.CardsLists
{
    public partial class CardsList<T>
    {
        [Parameter, EditorRequired]
        public List<T>? Items { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment<T>? ItemRenderFragment { get; set; }

        public void DebugClicked()
        {
            ;
        }
    }
}
