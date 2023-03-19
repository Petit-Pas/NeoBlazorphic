using Microsoft.AspNetCore.Components;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelectorButtonContent : ComponentBase
    {
        private CircularSelector? selector;
        private RenderFragment? childContent = null;

        [Parameter]
        public RenderFragment? ChildContent { get => childContent; set { childContent = value; SendToParent(); } }
        [Parameter]
        public string? CenterText { get; set; }

        [Parameter] 
        public double xShift { get; set; } = 0;

        [Parameter]
        public double yShift { get; set; } = 0;

        [CascadingParameter]
        public CircularSelector Selector { get => selector; set { selector = value; SendToParent(); } }

        [Parameter]
        public string AdditionalClass { get; set; }

        [Parameter]
        public string SelectedClass { get; set; }

        private void SendToParent()
        {
            if (selector != null && ChildContent != null)
            {
                selector.AddButtonContentIfMissing(this);
            }
        }
    }
}
