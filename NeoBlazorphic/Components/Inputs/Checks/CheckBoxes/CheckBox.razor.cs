using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Inputs.Checks.CheckBoxes;

public partial class CheckBox : ComponentBase
{
    private async Task OnMouseClick(MouseEventArgs args)
    {
        if (IsEnabled)
        {
            IsChecked = !IsChecked;
            await IsCheckedChanged.InvokeAsync(IsChecked);
        }
    }
}