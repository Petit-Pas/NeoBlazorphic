using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Inputs.Buttons;

public partial class ButtonCard : ComponentBase
{
    protected virtual async Task OnMouseClick(MouseEventArgs args)
    {
        await OnMouseClickCallBack.InvokeAsync(args);
    }
}