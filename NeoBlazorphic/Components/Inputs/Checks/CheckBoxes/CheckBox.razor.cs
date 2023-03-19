using Microsoft.AspNetCore.Components.Web;

namespace NeoBlazorphic.Components.Inputs.Checks.CheckBoxes;

public partial class CheckBox
{
    private async Task OnMouseClick(MouseEventArgs args)
    {
        if (!IsEnabled)
        {
            return;
        }

        IsChecked = !IsChecked;
        await IsCheckedChanged.InvokeAsync(IsChecked);
    }
}