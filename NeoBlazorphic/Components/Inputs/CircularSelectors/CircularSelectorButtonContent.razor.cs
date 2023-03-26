using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelectorButtonContent<T> : ComponentBase
    {
        private CircularSelector<T>? selector;
        private RenderFragment? childContent = null;

        /// <summary>
        ///     A possible SelectableItem if you want the ISelectableItemList features
        ///     Can remain null otherwise
        /// </summary>
        [Parameter]
        public T? Item { get; set; }

        /// <summary>
        ///     Tells whether that button should react to the mouse or not
        /// </summary>
        [Parameter] 
        public bool Disabled { get; set; } = false;

        /// <summary>
        ///     Exposing click event on the button
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseClickCallBack { get; set; }
        
        public async Task OnMouseClick(MouseEventArgs args)
        {
            await OnMouseClickCallBack.InvokeAsync(args);
        }


        /// <summary>
        ///     Exposing over event on the button
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOverCallBack { get; set; }
        
        public async Task OnMouseOver(MouseEventArgs args)
        {
            await OnMouseOverCallBack.InvokeAsync(args);
        }

        /// <summary>
        ///     The content to display
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get => childContent; set { childContent = value; SendToParent(); } }

        /// <summary>
        ///     An arbitrary value to shift the content inside the button on the x axis
        /// </summary>
        [Parameter] 
        public double xShift { get; set; } = 0;

        /// <summary>
        ///     An arbitrary value to shift the content inside the button on the y axis
        /// </summary>
        [Parameter]
        public double yShift { get; set; } = 0;

        [CascadingParameter]
        public CircularSelector<T>? Selector { get => selector; set { selector = value; SendToParent(); } }

        /// <summary>
        ///     Additional classes to apply on the button itself
        /// </summary>
        [Parameter]
        public string AdditionalClass { get; set; } = "";

        /// <summary>
        ///     A class applied on the button as a while when when the element is selected
        ///     Only works if Item is of type ISelectableItem.
        /// </summary>
        [Parameter]
        public string SelectedClass { get; set; } = "";

        private void SendToParent()
        {
            if (selector != null && ChildContent != null)
            {
                selector.AddButtonContentIfMissing(this);
            }
        }
    }
}
