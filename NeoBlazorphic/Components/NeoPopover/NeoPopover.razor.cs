using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace NeoBlazorphic.Components.NeoPopover;

public partial class NeoPopover : IDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; }

    
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RenderFragment? PopoverContent { get; set; }

    private bool _displayPopover = false;

    private Guid InternalId = Guid.NewGuid();

    // TODO if many popup keeps appearing, when there is an opened popover, we should close it, no matter what it is, before opening a new one.

    public async Task TogglePopoverAsync()
    {
        if (_displayPopover)
        {
            HidePopover();
            await _jsRuntime.InvokeVoidAsync("unregisterClickExceptForElement");
            
        }
        else
        {
            await ShowPopoverAsync();
        }
    }

    public void HidePopover()
    {
        _displayPopover = false;
        StateHasChanged();
    }

    public async Task ShowPopoverAsync()
    {
        _displayPopover = true;
        await _jsRuntime.InvokeVoidAsync("registerClickExceptForElement", nameof(ClickedOutsideOfElement), DotNetObjectReference.Create(this), InternalId);
        StateHasChanged();
    }

    [JSInvokable]
    public void ClickedOutsideOfElement()
    {
        HidePopover();
    }

    public void Dispose()
    {
        if (_displayPopover)
        {
            _jsRuntime.InvokeVoidAsync("unregisterClickExceptForElement");
        }
    }
}
