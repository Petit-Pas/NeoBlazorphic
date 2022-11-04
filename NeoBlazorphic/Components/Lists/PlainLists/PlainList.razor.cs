using System.Collections;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Lists.PlainLists
{
    public partial class PlainList<T> : ComponentBase
    {
        [Parameter] 
        public RenderFragment<T?>? ItemRenderFragment { get; set; } = default;

        [Parameter, EditorRequired]
        public IEnumerable? Items { get; set; }

        [Parameter] 
        public ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

        private T[] DisplayableItems()
        {
            if (Items is IEnumerable<T> items)
            {
                return items.ToArray();
            //    if (Filter == null || string.IsNullOrEmpty(SearchBarQuery))
            //    {
            //        return items.ToArray();
            //    }
            //    return items.Where(x => Filter(x, SearchBarQuery)).ToArray();
            }
            return Array.Empty<T>();
        }
    }
}
