using Microsoft.AspNetCore.Components;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class NewCircularSelectorButtonContent : ComponentBase
    {
        private NewCircularSelector? selector;
        private RenderFragment? childContent = null;

        [Parameter]
        public RenderFragment? ChildContent { get => childContent; set { childContent = value; SendToParent(); } }
        [Parameter]
        public string? CenterText { get; set; }

        [CascadingParameter]
        public NewCircularSelector Selector { get => selector; set { selector = value; SendToParent(); } }

        private void SendToParent()
        {
            if (selector != null && ChildContent != null) {
                if (!Selector.ButtonContents.Contains(this))
                {
                    Selector.ButtonContents.Add(this);
                    Selector.NotifyChangeOfState();
                }
            }
        }
    }
}
