using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Base.Cards;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class Card : ComponentBase
{
    protected virtual async Task OnMouseClick(MouseEventArgs args)
    {
        await OnMouseClickCallBack.InvokeAsync(args);
    }
}