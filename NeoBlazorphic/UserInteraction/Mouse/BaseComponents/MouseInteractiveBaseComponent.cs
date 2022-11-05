using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using NeoBlazorphic.Components;

namespace NeoBlazorphic.UserInteraction.Mouse.BaseComponents
{
    public abstract class MouseInteractiveBaseComponent : UiComponentBase
    {
        [Inject]
        protected IJSRuntime _jsRuntime { get; set; } = null!;

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOverCallBack { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOutCallBack { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDownCallBack { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUpCallBack { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseClickCallBack { get; set; }

        protected bool IsHovered {
            get => _isHovered;
            set {
                if (_isHovered != value)
                {
                    _isHovered = value;
                    StateUpdated();
                }
            }
        }
        private bool _isHovered = false;

        protected virtual void StateUpdated()
        {
        }
        

        [JSInvokable]
        public void MouseUpFromJs(MouseEventArgs args)
        {
            OnMouseUp(args);
        }

        // This should be overriden and called at the end to bubble up the event to the parent of the element in case interested
        // It enables to at least have a custom inner comportment on the event before bubbling it up
        protected virtual async Task OnMouseOver(MouseEventArgs args)
        {
            IsHovered = true;
            await OnMouseOverCallBack.InvokeAsync(args);
        }

        // This should be overriden and called at the end to bubble up the event to the parent of the element in case interested
        // It enables to at least have a custom inner comportment on the event before bubbling it up
        protected virtual async Task OnMouseOut(MouseEventArgs args)
        {
            IsHovered = false;
            await OnMouseOutCallBack.InvokeAsync(args);
        }

        // This should be overriden and called at the end to bubble up the event to the parent of the element in case interested
        // It enables to at least have a custom inner comportment on the event before bubbling it up
        protected virtual async Task OnMouseDown(MouseEventArgs args)
        {
            await CustomMouseDown(args);
            await OnMouseDownCallBack.InvokeAsync(args);
        }

        // This should be overriden and called at the end to bubble up the event to the parent of the element in case interested
        // It enables to at least have a custom inner comportment on the event before bubbling it up
        protected virtual async Task OnMouseUp(MouseEventArgs args)
        {
            await OnMouseUpCallBack.InvokeAsync(args);
        }

        // This should be overriden and called at the end to bubble up the event to the parent of the element in case interested
        // It enables to at least have a custom inner comportment on the event before bubbling it up
        protected virtual async Task OnMouseClick(MouseEventArgs args)
        {
            await OnMouseClickCallBack.InvokeAsync(args);
        }

        // Since the mouseUp event is fired on the element where the mouse is when it happens by default, we register to it on a document level to fire it here instead.
        private async Task CustomMouseDown(MouseEventArgs args)
        {
            await _jsRuntime.InvokeVoidAsync("window.registerToMouseUpWithGeneralScope", "NeoBlazorphic", "MouseUpFromJs", DotNetObjectReference.Create(this));
            await OnMouseDownCallBack.InvokeAsync(args);
        }
    }
}
