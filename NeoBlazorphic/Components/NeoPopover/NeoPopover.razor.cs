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

    public bool PopoverOpened = false;

    [Parameter]
    public EventCallback PopoverOpenedChanged { get; set; }

    private Guid InternalId = Guid.NewGuid();

    // TODO if many popup keeps appearing, when there is an opened popover, we should close it, no matter what it is, before opening a new one.

    public async Task TogglePopoverAsync()
    {
        if (PopoverOpened)
        {
            HidePopover();
            await _jsRuntime.InvokeVoidAsync("unregisterClickExceptForElement");
            
        }
        else
        {
            await ShowPopoverAsync();
        }
    }

    public async void HidePopover()
    {
        PopoverOpened = false;
        StateHasChanged();
        await OnPopoverOpenedChanged();
    }

    public async Task ShowPopoverAsync()
    {
        PopoverOpened = true;
        await _jsRuntime.InvokeVoidAsync("registerClickExceptForElement", nameof(ClickedOutsideOfElement), DotNetObjectReference.Create(this), InternalId);
        StateHasChanged();
        await OnPopoverOpenedChanged();
    }

    private async Task OnPopoverOpenedChanged()
    {
        await PopoverOpenedChanged.InvokeAsync();
    }

    [JSInvokable]
    public void ClickedOutsideOfElement()
    {
        HidePopover();
    }

    public void Dispose()
    {
        if (PopoverOpened)
        {
            _jsRuntime.InvokeVoidAsync("unregisterClickExceptForElement");
        }
    }
}
