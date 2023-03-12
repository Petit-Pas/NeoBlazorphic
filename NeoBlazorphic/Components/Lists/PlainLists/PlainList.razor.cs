using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Components.Base;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Lists.PlainLists
{
    public partial class PlainList<T> : NeoSelectableListComponentBase<T>
    {
        [Parameter] 
        public override BorderRadius BorderRadius { get; set; } = new(0.75, "em");
    }
}
