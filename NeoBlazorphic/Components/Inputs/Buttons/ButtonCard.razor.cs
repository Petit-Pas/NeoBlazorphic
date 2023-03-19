using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Inputs.Buttons;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class ButtonCard 
{
    protected virtual async Task OnMouseClick(MouseEventArgs args)
    {
        await OnMouseClickCallBack.InvokeAsync(args);
    }
}