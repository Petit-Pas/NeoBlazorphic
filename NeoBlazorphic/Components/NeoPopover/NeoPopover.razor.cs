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
            await _jsRuntime.InvokeVoidAsync("registerClickExceptForElement", nameof(ClickedOutsideOfElement), DotNetObjectReference.Create(this), "popoverId");
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
