using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace NeoBlazorphic.Components.NeoPopover;

public partial class NeoPopover
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; }

    
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RenderFragment? PopoverContent { get; set; }

    private bool _displayPopover = false;

    private Guid InternalId = Guid.NewGuid();

    // TODO, when there is an opened popover, we should close it, no matter what it is, before opening a new one.

    public async Task TogglePopover()
    {
        _displayPopover = !_displayPopover;
        await HandleClickOutsideOfElementEvent(_displayPopover);
        StateHasChanged();
    }

    private async Task HandleClickOutsideOfElementEvent(bool value)
    {
        if (value)
        {
            await _jsRuntime.InvokeVoidAsync("registerClickExceptForElement", nameof(ClickedOutsideOfElement), DotNetObjectReference.Create(this), InternalId);
        }
        else
        {
            await _jsRuntime.InvokeVoidAsync("unregisterClickExceptForElement", value);
        }
    }

    [JSInvokable]
    public async Task ClickedOutsideOfElement()
    {
        await TogglePopover();
    }

}
